using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Vdf;

namespace NeXt.APT.VdfIntegration
{
    class AlterationMadeEventArgs
    {
        public AlterationMadeEventArgs(VdfValue previous, VdfValue newval, VdfValue following)
        {
            Previous = previous;
            NewValue = newval;
            Next = following;
        }

        public VdfValue Previous { get; private set; }
        public VdfValue NewValue { get; private set; }
        public VdfValue Next { get; private set; }
    }
}
