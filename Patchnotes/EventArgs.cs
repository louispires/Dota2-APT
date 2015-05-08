using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.APT.NameTranslator;

namespace NeXt.APT.Patchnotes
{
    public class NotFoundEventArgs : EventArgs
    {
        public NotFoundEventArgs(string rawText) : base()
        {
            RawText = rawText;
        }

        public string RawText { get; private set; }
    }

    public class HeroChangedEventArgs : EventArgs
    {
        public HeroChangedEventArgs(Hero hero)
        {
            Hero = hero;
        }
        public Hero Hero { get; private set; }
    }

    public class AbilityChangeReadyEventArgs : EventArgs
    {
        public AbilityChangeReadyEventArgs(Ability ability, string text)
        {
            Ability = ability;
            Text = text;
        }

        public Ability Ability { get; private set; }
        public string Text { get; private set; }
    }

    public class ItemChangeReadyEventArgs : EventArgs
    {
        public ItemChangeReadyEventArgs(Item item, string text)
        {
            Item = item;
            Text = text;
        }

        public Item Item { get; private set; }
        public string Text { get; private set; }
    }
}
