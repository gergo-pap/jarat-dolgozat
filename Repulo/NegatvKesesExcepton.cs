using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repulo
{
    class NegatvKesesExcepton: Exception
    {
        public NegatvKesesExcepton(int keses)
            : base("Nem lehet az összes késés értéke negatív, módosítsd ezt az értéket: " + keses)

        {

        }

    }
}
