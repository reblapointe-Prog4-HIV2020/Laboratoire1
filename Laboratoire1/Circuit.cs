using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegepJonquiere.RebLapointe.Laboratoire1.Utils;

namespace CegepJonquiere.RebLapointe.Laboratoire1
{
    public abstract class Circuit : IComposant
    {
        protected List<IComposant> sousCircuits;

        protected double courrant;
        protected double tension;

        public double GetCourrant()
        {
            return courrant;
        }

        public double GetTension()
        {
            return tension;
        }
        
        public Circuit()
        {
            sousCircuits = new List<IComposant>();
        }

        public void AddSousCircuit(IComposant c)
        {
            sousCircuits.Add(c);
        }

        public abstract double CalculerResistance();
        public abstract void MettreSousTension(double tension);
        public abstract void SpecifierCourrant(double courrant);
        public abstract string Dessiner();

        public override string ToString()
        {
            return MultiplicateurHelper.MultiplicateurString(CalculerResistance()) + "Ω " +
                    MultiplicateurHelper.MultiplicateurString(GetCourrant()) + "A " +
                    MultiplicateurHelper.MultiplicateurString(GetTension()) + "V.";
        }
        
    }
}
