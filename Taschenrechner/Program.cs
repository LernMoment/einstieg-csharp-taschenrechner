using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Story "Addieren": Als Benutzer möchte ich zwei Zahlen eingeben, um deren Summe berechnen zu lassen.
            Console.Write("Bitte gib den ersten Summanden ein: ");
            string ersterSummand = Console.ReadLine();
            Console.Write("Bitte gib den zweiten Summanden ein: ");
            string zweiterSummand = Console.ReadLine();

            // Wandel Text in Gleikommazahlen
            double ersterSummandAlsZahl = Convert.ToDouble(ersterSummand);
            double zweiterSummandAlsZahl = Convert.ToDouble(zweiterSummand);

            // Berechnung ausführen
            double summe = ersterSummandAlsZahl + zweiterSummandAlsZahl;

            // Ausgabe
            Console.WriteLine("Die Summe ist: {0}", summe);
            WarteAufBenutzerEingabe();
        }

        static void WarteAufBenutzerEingabe()
        {
            Console.Write("Zum beenden bitte Return drücken!");
            Console.ReadLine();
        }
    }
}
