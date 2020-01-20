using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepJonquiere.RebLapointe.Laboratoire1
{
    public class Resistance : IComposant
    {
        private double valeur;
        private double courrant;
        private double tension;

        public double Tolerance { get; set; }

        public Resistance()
        {
            valeur = 1;
        }

        private void ValiderValeur(double valeur)
        {
            if (valeur <= 0)
                throw new ArgumentException("Une résitance doit avoir une valeur strictement positive.");
        }
    
        public Resistance(double valeur, double tolerance)
        {
            ValiderValeur(valeur);
            this.valeur = valeur;
            this.Tolerance = tolerance;
        }

        public Resistance(double valeur)
        {
            ValiderValeur(valeur);
            this.valeur = valeur;
            this.Tolerance = 0;
        }

        public void SpecifierCourrant(double courrant)
        {
            this.courrant = courrant;
            this.tension = courrant * CalculerResistance();
        }

        public void MettreSousTension(double tension)
        {
            this.tension = tension;
            this.courrant = tension / CalculerResistance();
        }

        public double GetValeur()
        {
            return valeur;
        }

        public void SetValeur(double valeur)
        {
            ValiderValeur(valeur);
            this.valeur = valeur;
        }

        public double GetTolerance()
        {
            return Tolerance;
        }

        public void SetTolerance(double tolerance)
        {
            this.Tolerance = tolerance;
        }

        public double CalculerResistance()
        {
            return valeur;
        }

        public double GetTension()
        {
            return tension;
        }

        public double GetCourrant()
        {
            return courrant;
        }
        
        public override string ToString()
        {
            return "{" + MultiplicateurHelper.MultiplicateurString(CalculerResistance()) + "Ω " +
                    MultiplicateurHelper.MultiplicateurString(GetCourrant()) + "A " +
                    MultiplicateurHelper.MultiplicateurString(GetTension()) + "V}";
        }

        public string Dessiner()
        {
            return ToString();
        }
    }
}
