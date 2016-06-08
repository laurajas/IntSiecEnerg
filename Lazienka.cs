﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Lazienka : Pomieszczenie
    {
        public override List<elementy> el { get; set; }
        public override string name { get; set; }
        public Lazienka(string name)
        {
            this.name = name;
            el = new List<elementy>();
        }
        public override void Reset(PobierajPrad prad)
        {
                prad.CzasDzialania = 0;
        }
    }
}
