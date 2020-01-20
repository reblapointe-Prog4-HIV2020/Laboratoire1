using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire1
{
    public class CircuitParallele : Circuit
    {
        public override double CalculerResistance()
        {
            double somme = 0;

            foreach (Composant c in sousCircuits)
                somme += 1 / c.CalculerResistance();

            return 1 / somme;
        }

        // V = I*R
       
        public override void MettreSousTension(double tension)
        {
            if (sousCircuits.Count == 0)
                throw new CircuitOuvertException();

            this.tension = tension;
            this.courrant = tension / CalculerResistance();

            foreach (Composant c in sousCircuits)
                c.MettreSousTension(tension);
        }

     public override void SpecifierCourrant(double courrant)
        {
            this.courrant = courrant;
            this.MettreSousTension(courrant * CalculerResistance());
        }

        public override String Dessiner()
        {
            StringBuilder ret = new StringBuilder("[");
            for (int i = 0; i < sousCircuits.Count; i++)
                ret.Append(sousCircuits[i].Dessiner()).Append(i == sousCircuits.Count - 1 ? "" : ",");
            return ret + "]";
        }
    }
}
