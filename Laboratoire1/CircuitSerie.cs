using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire1
{
    public class CircuitSerie : Circuit
    {
        public override void MettreSousTension(double tension)
        {
            this.tension = tension;
            if (sousCircuits.Count == 0)
                throw new CircuitOuvertException();

            this.SpecifierCourrant(tension / CalculerResistance());
        }

        // V = I*R
        public override void SpecifierCourrant(double courrant)
        {
            this.courrant = courrant;
            this.tension = courrant * CalculerResistance();

            if (sousCircuits.Count == 0)
                throw new CircuitOuvertException();

            foreach (Composant c in sousCircuits)
                c.SpecifierCourrant(courrant);
        }
        
        public override double CalculerResistance()
        {
            double somme = 0;

            foreach (Composant c in sousCircuits)
                somme += c.CalculerResistance();

            return somme;

        }

        public override String Dessiner()
        {
            StringBuilder ret = new StringBuilder("(");
            for (int i = 0; i < sousCircuits.Count; i++)
                ret.Append(sousCircuits[i].Dessiner()).Append(i == sousCircuits.Count - 1 ? "" : ", ");
            return ret + ")";
        }
    }
}
