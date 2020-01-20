using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepJonquiere.RebLapointe.Laboratoire1
{
    public interface IComposant
    {
        double CalculerResistance(); // Unité = Ohm,    Symbole = Ω, Dans les équations : R
        double GetCourrant();        // Unité = Ampère, Symbole = A, Dans les équations : I. (Intensité)
        double GetTension();         // Unité = Volt,   Symbole = V, Dans les équations : V ou U.

        void MettreSousTension(double tension);
        void SpecifierCourrant(double courrant);

        string Dessiner();
    }
}
