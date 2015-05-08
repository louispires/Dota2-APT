using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.APT.NameTranslator;

namespace NeXt.APT.Patchnotes
{
    public class Translator
    {
        public event EventHandler<NotFoundEventArgs> HeroNotFound = delegate { };
        public event EventHandler<NotFoundEventArgs> AbilityNotFound = delegate { };
        public event EventHandler<NotFoundEventArgs> MatchingHeroNotFound = delegate { };
        public event EventHandler<AbilityChangeReadyEventArgs> AbilityChangeReady = delegate { };
        public event EventHandler<HeroChangedEventArgs> HeroChanged = delegate { };

        protected void DoHeroNotFound(string raw)
        {
            HeroNotFound(this, new NotFoundEventArgs(raw));
        }

        protected void DoAbilityNotFound(string raw)
        {
            AbilityNotFound(this, new NotFoundEventArgs(raw));
        }

        protected void DoMatchingHeroNotFound(string raw)
        {
            MatchingHeroNotFound(this, new NotFoundEventArgs(raw));
        }

        protected void DoAbilityChangeReady(Ability ability, string text)
        {
            AbilityChangeReady(this, new AbilityChangeReadyEventArgs(ability, text));
        }

        protected void DoHeroChanged(Hero hero)
        {
            HeroChanged(this, new HeroChangedEventArgs(hero));
        }

        public event EventHandler<NotFoundEventArgs> ItemNotFound = delegate { };
        public event EventHandler<NotFoundEventArgs> MatchingItemNotFound = delegate { };
        public event EventHandler<ItemChangeReadyEventArgs> ItemChangeReady = delegate { };

        protected void DoItemNotFound(string raw)
        {
            ItemNotFound(this, new NotFoundEventArgs(raw));
        }

        protected void DoMatchingItemNotFound(string raw)
        {
            MatchingItemNotFound(this, new NotFoundEventArgs(raw));
        }

        protected void DoItemChangeReady(Item item, string text)
        {
            ItemChangeReady(this, new ItemChangeReadyEventArgs(item, text));
        }


        private List<Hero> heroes = Hero.Build();
        private List<Item> items = Item.BuildList();

        private bool GetUnindentedLine(string line, out string uiLine)
        {
            var oldLen = line.Length;
            var l = line.TrimStart();
            var newLen = l.Length;
            l = l.TrimEnd();

            uiLine = l;
            return oldLen <= newLen;
        }

        public void TranslateRawHeroes(string text)
        {
            var lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Hero hero = null;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    continue;
                }

                string l;

                if (GetUnindentedLine(line, out l))
                {
                    hero = null;
                    foreach (var h in heroes)
                    {
                        if (h.MatchesName(l))
                        {
                            hero = h;
                            break;
                        }
                    }

                    if (hero == null)
                    {
                        DoHeroNotFound(l);
                    }
                    else
                    {
                        DoHeroChanged(hero);
                    }
                    continue;
                }

                if (hero == null)
                {
                    DoMatchingHeroNotFound(l);
                    continue;
                }

                var abilities = hero.MatchingAbilities(l);

                if (abilities.Length > 1)
                {
                    foreach (var ability in abilities)
                    {
                        DoAbilityChangeReady(ability, l);
                    }
                }
                else if (abilities.Length == 1)
                {
                    var ability = abilities[0];
                    if (!ability.IsMinor  && l.IndexOf(ability.DisplayName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        l = l.Remove(0, ability.DisplayName.Length).TrimStart();
                    }

                    DoAbilityChangeReady(ability, l);
                }
                else
                {
                    DoAbilityNotFound(l);
                }

            }
        }

        public void TranslateRawItems(string text)
        {
            var lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Item item = null;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    continue;
                }

                string l;

                if (GetUnindentedLine(line, out l))
                {
                    item = null;
                    foreach (var i in items)
                    {
                        if (i.MatchesName(l))
                        {
                            item = i;
                            break;
                        }
                    }

                    if (item == null)
                    {
                        DoItemNotFound(l);
                    }
                    continue;
                }

                if (item == null)
                {
                    DoMatchingItemNotFound(l);
                    continue;
                }

                int index;
                if ( (index = l.IndexOf(item.DisplayName, StringComparison.OrdinalIgnoreCase)) == 0)
                {
                    var i2 = l.IndexOf(' ', index + item.DisplayName.Length);
                    l = l.Remove(0, i2).TrimStart();
                }

                DoItemChangeReady(item, l);
            }
        }
    }
}
