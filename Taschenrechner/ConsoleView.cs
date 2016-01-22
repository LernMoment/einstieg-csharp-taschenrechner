using System;

namespace Taschenrechner
{
    class ConsoleView
    {
        private RechnerModel model;

        public ConsoleView(RechnerModel model)
        {
            this.model = model;
        }

        public string HoleZahlVomBenutzer()
        {
            Console.Write("Bitte gib eine Zahl für die Berechnung ein: ");
            return Console.ReadLine();
        }

        public string HoleOperatorVomBenutzer()
        {
            Console.Write("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
            return Console.ReadLine();
        }

        public void WarteAufEndeDurchBenutzer()
        {
            Console.Write("Zum beenden bitte Return drücken!");
            Console.ReadLine();
        }

        public void GibResultatAus(string operation)
        {
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Die Summe ist: {0}", model.Resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz ist: {0}", model.Resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Wert des Quotienten ist: {0}", model.Resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt ist: {0}", model.Resultat);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen.");
                    break;
            }
        }
    }
}
