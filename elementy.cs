using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class elementy : PobierajPrad
    {
       public string name { get; set; }
       public int IloscWat { get; set; }
       public bool Pobieraj { get; set; }
       public int CzasDzialania { get; set; }
        public elementy(string name,int IloscWat)
        {
            this.name = name;
            CzasDzialania = 0;
            this.IloscWat = IloscWat;
        }
    }
}
