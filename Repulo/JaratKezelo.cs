using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repulo
{
    class JaratKezelo
    {
        List<Jarat> jaratok = new List<Jarat>();
        Jarat jarat;

        public void UjJarat(string jaratszam,string repterHonnan, string repterHova,DateTime indulas)
        {
            var jar = new Jarat(jaratszam, repterHonnan, repterHova, indulas);
            foreach (var jarat in jaratok)
            {
                if (jarat.JaratSzam.Equals(jaratszam))
                {
                    throw new ArgumentException("Ilyen járat már van");
                }
            }
            jaratok.Add(jar);
        }

        public void Keses(string jaratszam, int keses)
        {
            foreach (var jarat in jaratok)
            {
                if (jaratszam.Equals(jarat.JaratSzam))
                {
                    if ((jarat.Keses + keses) < 0)
                    {
                        throw new NegatvKesesExcepton(keses);
                    }
                    else
                    {
                        jarat.Keses += keses;
                    }
                }
            }
        }

        public DateTime MikorIndul(string jaratszam)
        {
            foreach (var jarat in jaratok)
            {
                if (jaratszam.Equals(jarat.JaratSzam))
                {
                    return jarat.Indulas.AddMinutes(jarat.Keses);
                }
            }
            throw new ArgumentException("Nem volt ilyen járat!");
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> jaratokList = new List<string>();
            foreach (var jarat in jaratok)
            {
                if (repter.Equals(jarat.HonnanRepter))
                {
                    jaratokList.Add(jarat.JaratSzam);
                   
                }
            }
            if (jaratokList.Count == 0)
            {
                throw new ArgumentException();
            }
            return jaratokList;
            
        }
    }
}
