using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.APT.NameTranslator
{
    static class FuzzyStringExtentions
    {
        public static double EditDistance(this string self, string compared)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }
            if (compared == null)
            {
                throw new ArgumentNullException("compared");
            }

            int RowLen = self.Length;
            int ColLen = compared.Length;
            if (RowLen == 0)
            {
                return ColLen;
            }
            if (ColLen == 0)
            {
                return RowLen;
            }
            int RowIdx;
            int ColIdx;
            char Row_i;
            char Col_j;
            int cost;
            int[] v0 = new int[RowLen + 1];
            int[] v1 = new int[RowLen + 1];
            int[] vTmp;
            for (RowIdx = 1; RowIdx <= RowLen; RowIdx++)
            {
                v0[RowIdx] = RowIdx;
            }
            for (ColIdx = 1; ColIdx <= ColLen; ColIdx++)
            {
                v1[0] = ColIdx;
                Col_j = compared[ColIdx - 1];
                for (RowIdx = 1; RowIdx <= RowLen; RowIdx++)
                {
                    Row_i = self[RowIdx - 1];
                    if (Row_i == Col_j)
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = 1;
                    }
                    int m_min = v0[RowIdx] + 1;
                    int b = v1[RowIdx - 1] + 1;
                    int c = v0[RowIdx - 1] + cost;

                    if (b < m_min)
                    {
                        m_min = b;
                    }
                    if (c < m_min)
                    {
                        m_min = c;
                    }
                    v1[RowIdx] = m_min;
                }
                vTmp = v0;
                v0 = v1;
                v1 = vTmp;
            }
            return ((double)v0[RowLen] / (double)System.Math.Max(RowLen, ColLen));
        }
    }
}
