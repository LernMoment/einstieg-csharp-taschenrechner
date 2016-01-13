using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Story "Addieren": Als Benutzer möchte ich zwei Zahlen eingeben, um deren Summe berechnen zu lassen.
            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die erste Zahl ein: ");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die zweite Zahl ein: ");
            string operation = HoleBenutzerEingabe("Bitte gib die auszuführende Operation ein (+, -, /, *): ");

            // Wandel Text in Gleikommazahlen
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist.
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            double resultat = Berechnung(ersteZahl, zweiteZahl, operation);

            // Ausgabe
            GibResultatAus(resultat, operation);
            HoleBenutzerEingabe("Zum beenden bitte Return drücken!");
        }

        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            return Console.ReadLine();
        }

        static double Berechnung(double ersteZahl, double zweiteZahl, string operation)
        {
            double resultat = 0;
            switch (operation)
            {
                case "+":
                    resultat = Addiere(ersteZahl, zweiteZahl);
                    break;

                case "-":
                    resultat = Subtrahiere(ersteZahl, zweiteZahl);
                    break;

                case "/":
                    resultat = Dividiere(ersteZahl, zweiteZahl);
                    break;

                case "*":
                    resultat = Multipliziere(ersteZahl, zweiteZahl);
                    break;
            }

            return resultat;
        }

        static void GibResultatAus(double resultat, string operation)
        {
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Die Summe ist: {0}", resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz ist: {0}", resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Wert des Quotienten ist: {0}", resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt ist: {0}", resultat);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen.");
                    break;
            }
        }

        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;

            return summe;
        }

        static double Subtrahiere(double minuend, double subtrahent)
        {
            double differenz = minuend - subtrahent;

            return differenz;
        }

        static double Dividiere(double dividend, double divisor)
        {
            return dividend / divisor;
        }

        static double Multipliziere(double multiplikator, double multiplikand)
        {
            return multiplikator * multiplikand;
        }
    }
}
