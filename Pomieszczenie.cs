using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    abstract class Pomieszczenie
    {
        public abstract void Reset(PobierajPrad prad);
        public abstract string name { get; set; }
        public abstract List<elementy> el { get; set; }
    }
}
