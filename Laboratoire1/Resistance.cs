using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire1
{
    public class Resistance : Composant
    {

        private double valeur;
        private double tolerance;
        private double courrant;
        private double tension;

        public Resistance()
        {
            valeur = 1;
        }

        private void validerValeur(double valeur)
        {
            if (valeur <= 0)
                throw new ArgumentException("Une résitance doit avoir une valeur strictement positive.");
        }
    
        public Resistance(double valeur, double tolerance)
        {
            validerValeur(valeur);
            this.valeur = valeur;
            this.tolerance = tolerance;
        }

        public Resistance(double valeur)
        {
            validerValeur(valeur);
            this.valeur = valeur;
            this.tolerance = 0;
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
            validerValeur(valeur);
            this.valeur = valeur;
        }

        public double GetTolerance()
        {
            return tolerance;
        }

        public void SetTolerance(double tolerance)
        {
            this.tolerance = tolerance;
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
        
        public override String ToString()
        {
            return "{" + MultiplicateurHelper.multiplicateurString(CalculerResistance()) + "Ω, " +
                    MultiplicateurHelper.multiplicateurString(GetCourrant()) + "A, " +
                    MultiplicateurHelper.multiplicateurString(GetTension()) + "V}";
        }

        public String Dessiner()
        {
            return ToString();
        }
    }
}
