using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire1
{
    public class MultiplicateurHelper
    {

        private static String[] MULTIPLICATEURS = { "n", "µ", "m", "", "k", "M", "G" };
        private static double[] MULTVAL = { 0.000_000_001, 0.000_001, 0.001, 1, 1_000, 1_000_000, 1_000_000_000 };

        private static double PRECISION = 10.0; // 1/PRECISION est la véritable précision

        public static String symboleMult(double valeur)
        {
            for (int i = MULTIPLICATEURS.Length - 1; i >= 0; i--)
                if (valeur >= MULTVAL[i])
                    return MULTIPLICATEURS[i];
            return "";
        }


        public static double multiplicateur(double valeur)
        {
            for (int i = MULTIPLICATEURS.Length - 1; i >= 0; i--)
                if (valeur >= MULTVAL[i])
                    return MULTVAL[i];
            return 1;
        }


        public static String multiplicateurString(double valeur)
        {
            return Math.Round((valeur * PRECISION) / multiplicateur(valeur)) / PRECISION + " " + symboleMult(valeur);
        }
    }
}
