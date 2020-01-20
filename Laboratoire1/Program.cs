using System;

namespace Laboratoire1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FabriqueCircuit.help());
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Entrez un circuit (code couleur ou valeur décimale)");
                Composant c = FabriqueCircuit.fromString(Console.ReadLine());
                Console.WriteLine("Entrez une tension (en volt)");
                c.MettreSousTension(Double.Parse(Console.ReadLine()));
                Console.WriteLine(c);
                Console.WriteLine(c.Dessiner());
            }
            catch (CircuitOuvertException)
            {
                Console.WriteLine("Circuit ouvert");
            }
            catch (ArgumentException iae)
            {
                Console.WriteLine(iae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("La chaîne entrée n'est pas un circuit valide");
            }
            Console.Read();
        }
    }
}
