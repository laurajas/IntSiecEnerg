using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Menu
    {
        public int Rachunek { get; set; }
        public List<Pomieszczenie> pom = new List<Pomieszczenie>();
    
        public string DodajPomieszczenia(Pomieszczenie pom)
        {
            this.pom.Add(pom);
            return this.pom.Last().name;
        }

        public void DodajElementy(string pomieszczenie,string rzecz,int wat)
        {
            foreach (Pomieszczenie element in pom)
            {
                if(element.name == pomieszczenie)
                    element.el.Add(new elementy(rzecz, wat));
            }
        }
        public bool StatusElementu(string pomieszczenie, string rzecz,bool status)
        {
            foreach (Pomieszczenie element in pom)
            {
                if (element.name == pomieszczenie)
                    for (int i=0;i<element.el.Count();i++)
                    {
                        if (element.el.ElementAt(i).name == rzecz)
                        {
                            element.el.ElementAt(i).Pobieraj = status;
                            return true;
                        }
                    }
            }
            return false;
        }

  
       public int ZuzyieElementu(string pomieszczenie, string rzecz)
        {
            foreach (Pomieszczenie element in pom)
            {
                if (element.name == pomieszczenie)
                    for (int i = 0; i < element.el.Count(); i++)
                    {
                        if (element.el.ElementAt(i).name == rzecz)
                        {
                            return element.el.ElementAt(i).CzasDzialania;
                        }
                    }
            }
            return 0;
        }

        public int PodliczenieRachunku()
        {
            Rachunek = 0;
            foreach (Pomieszczenie element in pom)
            {
                    for (int i = 0; i < element.el.Count(); i++)
                    { 
                        Rachunek += element.el.ElementAt(i).IloscWat* element.el.ElementAt(i).CzasDzialania;  
                    }
            }
            return Rachunek;
        }


        public int Zaplata()
        {
           
            foreach (Pomieszczenie element in pom)
            {
                for (int i = 0; i < element.el.Count(); i++)
                {
                    element.Reset(element.el.ElementAt(i));
                }
            }
            Rachunek = 0;
            return Rachunek;
        }
    }
}
