using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Vdf;

namespace NeXt.APT.VdfIntegration
{
    class VdfAlterer
    {
        public VdfAlterer(VdfTable table, AlterationData data)
        {
            this.table = table;
            this.data = data;
        }

        private VdfTable table;
        private AlterationData data;

        public event EventHandler<AlterationMadeEventArgs> AlterationMade = delegate { };

        protected void OnAlterationMade(VdfValue p, VdfValue newv, VdfValue n)
        {
            AlterationMade(this, new AlterationMadeEventArgs(p, newv, n));
        }

        public void Apply()
        {

            foreach(var change in data.HeroChanges.Concat(data.ItemChanges))
            {
                foreach(var text in change.Texts)
                {
                    int i = 0;
                    while(table.ContainsName(string.Concat(change.BaseName, "_Note", i)))
                    {
                        i++;
                    }

                    VdfValue prepender = null;
                    VdfValue appender = null;
                    if(i > 0)
                    {
                        prepender = table.GetByName(string.Concat(change.BaseName, "_Note", i - 1));
                    }
                    else
                    {
                        prepender = table.GetByName(string.Concat(change.BaseName, "_Description"));
                    }
                    if(prepender == null)
                    {
                        prepender = table.GetByName(string.Concat(change.BaseName, "_Lore"));
                    }
                    if(prepender == null)
                    {
                        table.Traverse(
                            delegate(VdfValue v)
                            {
                                if(v.Name.IndexOf(change.BaseName) >= 0)
                                {
                                    prepender = v;
                                }
                                return true;
                            }
                        );
                    }

                    if(prepender == null)
                    {
                        throw new Exception("this should never happen");
                    }

                    var idx = table.IndexOf(prepender);
                    if(idx < table.Count - 1)
                    {
                        appender = table[idx + 1];
                    }

                    var newval = new VdfString(string.Concat(change.BaseName, "_Note", i), "<font color='#669999'>"+text+"</font>");

                    table.InsertAfter(prepender, newval);
                    OnAlterationMade(prepender, newval, appender);
                }
            }
        }
    }
}
