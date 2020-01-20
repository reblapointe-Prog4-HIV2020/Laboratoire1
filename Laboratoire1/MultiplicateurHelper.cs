using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepJonquiere.RebLapointe.Laboratoire1
{
    public class MultiplicateurHelper
    {
        private static readonly IReadOnlyList<string> MULTIPLICATEURS = new [] { "n", "µ", "m", "", "k", "M", "G" };
        private static readonly IReadOnlyList<double> MULTVAL = new[] { 0.000_000_001, 0.000_001, 0.001, 1, 1_000, 1_000_000, 1_000_000_000 };

        private const double PRECISION = 10.0; // 1/PRECISION est la véritable précision

        public static string SymboleMult(double valeur)
        {
            for (int i = MULTIPLICATEURS.Count - 1; i >= 0; i--)
                if (valeur >= MULTVAL[i])
                    return MULTIPLICATEURS[i];
            return "";
        }


        public static double Multiplicateur(double valeur)
        {
            for (int i = MULTIPLICATEURS.Count - 1; i >= 0; i--)
                if (valeur >= MULTVAL[i])
                    return MULTVAL[i];
            return 1;
        }


        public static string MultiplicateurString(double valeur)
        {
            return Math.Round((valeur * PRECISION) / Multiplicateur(valeur)) / PRECISION + " " + SymboleMult(valeur);
        }
    }
}
