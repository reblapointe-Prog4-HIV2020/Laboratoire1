using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepJonquiere.RebLapointe.Laboratoire1
{
    public sealed class CodeCouleur
    {
        public static readonly CodeCouleur N = new CodeCouleur("N", EnumInterne.N, "Noir", 0, 0, 0, 1, 0.2, "(N)oir 0");
        public static readonly CodeCouleur B = new CodeCouleur("B", EnumInterne.B, "Brun", 1, 1, 1, 10, 0.01, "(B)run 1");
        public static readonly CodeCouleur R = new CodeCouleur("R", EnumInterne.R, "Rouge", 2, 2, 2, 100, 0.02, "(R)ouge 2");
        public static readonly CodeCouleur O = new CodeCouleur("O", EnumInterne.O, "Orange", 3, 3, 3, 1_000, 0.03, "(O)range 3");
        public static readonly CodeCouleur J = new CodeCouleur("J", EnumInterne.J, "Jaune", 4, 4, 4, 10_000, 1, "(J)aune 4");
        public static readonly CodeCouleur V = new CodeCouleur("V", EnumInterne.V, "Vert", 5, 5, 5, 100_000, 0.00_5, "(V)ert 5");
        public static readonly CodeCouleur b = new CodeCouleur("b", EnumInterne.b, "Bleu", 6, 6, 6, 1_000_000, 0.00_25, "(b)leu 6");
        public static readonly CodeCouleur M = new CodeCouleur("M", EnumInterne.M, "Mauve", 7, 7, 7, 10_000_000, 0.00_1, "(M)auve 7");
        public static readonly CodeCouleur G = new CodeCouleur("G", EnumInterne.G, "Gris", 8, 8, 8, 100_000_000, 0.00_05, "(G)ris 8");
        public static readonly CodeCouleur L = new CodeCouleur("L", EnumInterne.L, "Blanc", 9, 9, 9, 1_000_000_000, 0.1, "B(L)anc 9");
        public static readonly CodeCouleur o = new CodeCouleur("o", EnumInterne.o, "Or", 0, 0, 0, 0.1, 0.05, "(o)r ±5%");
        public static readonly CodeCouleur A = new CodeCouleur("A", EnumInterne.A, "Argent", 0, 0, 0, 0.01, 0.1, "(A)rgent ±10%");


        private static readonly IList<CodeCouleur> valueList = new List<CodeCouleur>();

        static CodeCouleur()
        {
            valueList.Add(N);
            valueList.Add(B);
            valueList.Add(R);
            valueList.Add(O);
            valueList.Add(J);
            valueList.Add(V);
            valueList.Add(b);
            valueList.Add(M);
            valueList.Add(G);
            valueList.Add(L);
            valueList.Add(o);
            valueList.Add(A);
        }

        public enum EnumInterne
        {
            N,B,R,O,J,V,b,M,G,L,o,A
        }

        public readonly string ValeurNom;
        public readonly EnumInterne Ei;
        public readonly string LongNom;
        public readonly int PremiereBande;
        public readonly int DeuxiemeBande;
        public readonly int TroisiemeBande;
        public readonly double Multiplicateur;
        public readonly double Tolerance;
        public readonly string Description;
        public readonly int Ordinal;
        public static int OrdinalSuivant = 0;

        CodeCouleur(string valeur, EnumInterne ie, string nom, int premiereBande, int deuxiemeBande, int troisiemeBande, double multiplicateur, double tolerance, string description)
        {
            this.ValeurNom = valeur;
            this.Ei = ie;
            this.LongNom = nom;
            this.PremiereBande = premiereBande;
            this.DeuxiemeBande = deuxiemeBande;
            this.TroisiemeBande = troisiemeBande;
            this.Multiplicateur = multiplicateur;
            this.Tolerance = tolerance;
            this.Description = description;
            this.Ordinal = (OrdinalSuivant++);
        }
        
        public static IList<CodeCouleur> Values()
        {
            return valueList;
        }

        public override string ToString()
        {
            return ValeurNom;
        }

        public static CodeCouleur ValueOf(string name)
        {
            foreach (CodeCouleur enumInstance in CodeCouleur.valueList)
                if (enumInstance.ValeurNom == name)
                    return enumInstance;
            throw new System.ArgumentException(name);
        }
    }
}

