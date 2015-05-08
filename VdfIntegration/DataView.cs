using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.APT.VdfIntegration
{
    public class Alteration
    {
        public Alteration(string baseName, IEnumerable<string> texts)
        {
            BaseName = baseName;
            Texts = texts;
        }

        public string BaseName { get; private set; }

        public IEnumerable<string> Texts { get; private set; }
    }

    public class AlterationData
    {
        public AlterationData(IEnumerable<Alteration> heroChanges, IEnumerable<Alteration> itemChanges)
        {
            HeroChanges = heroChanges;
            ItemChanges = itemChanges;
        }

        public IEnumerable<Alteration> HeroChanges { get; private set; }
        public IEnumerable<Alteration> ItemChanges { get; private set; }
    }

    public class AlterationDataBuilder
    {
        private enum AlterationType
        {
            None,
            Hero,
            Item,
        }

        public AlterationDataBuilder()
        {
            heroChanges = new List<Alteration>();
            itemChanges = new List<Alteration>();
            currentChanges = new List<string>();
            t = AlterationType.None;
        }

        private List<Alteration> heroChanges;
        private List<Alteration> itemChanges;

        private List<string> currentChanges;
        private string currentName;
        private AlterationType t;

        private void addCurrent()
        {
            if(t == AlterationType.None)
            {
                return;
            }

            switch(t)
            {
                case AlterationType.Hero:
                {
                    heroChanges.Add(new Alteration(currentName, currentChanges.AsReadOnly()));
                    break;
                }
                case AlterationType.Item:
                {
                    itemChanges.Add(new Alteration(currentName, currentChanges.AsReadOnly()));
                    break;
                }
            }
            currentChanges = new List<string>();
            currentName = string.Empty;

            t = AlterationType.None;
        }

        public AlterationDataBuilder AddAbility(string baseName)
        {
            if(t != AlterationType.None)
            {
                addCurrent();
            }

            currentName = baseName;
            t = AlterationType.Hero;

            return this;
        }

        public AlterationDataBuilder AddItem(string baseName)
        {
            if (t != AlterationType.None)
            {
                addCurrent();
            }

            currentName = baseName;
            t = AlterationType.Item;

            return this;
        }

        public AlterationDataBuilder Append(string text)
        {
            currentChanges.Add(text);
            return this;
        }

        public AlterationData Build()
        {
            if (t != AlterationType.None)
            {
                addCurrent();
            }

            var data = new AlterationData(heroChanges, itemChanges);

            heroChanges = new List<Alteration>();
            itemChanges = new List<Alteration>();
            currentChanges = new List<string>();

            return data;
        }
    }
}
