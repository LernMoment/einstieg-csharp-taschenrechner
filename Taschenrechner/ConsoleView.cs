using System;

namespace Taschenrechner
{
    class ConsoleView
    {
        private RechnerModel model;

        public ConsoleView(RechnerModel model)
        {
            this.model = model;
            BenutzerWillBeenden = false;
        }

        public bool BenutzerWillBeenden { get; private set; }

        public void HoleEingabenFuerErsteBerechnungVomBenutzer()
        {
            model.ErsteZahl = HoleZahlVomBenutzer();
            model.Operation = HoleOperatorVomBenutzer();
            model.ZweiteZahl = HoleZahlVomBenutzer();
        }

        public void HoleEingabenFuerFortlaufendeBerechnung()
        {
            string eingabe = HoleNaechsteAktionVomBenutzer();

            if (eingabe == "Fertig")
            {
                BenutzerWillBeenden = true;
            }
            else
            {
                model.ErsteZahl = model.Resultat;
                model.ZweiteZahl = Convert.ToDouble(eingabe);
            }
        }

        private string HoleNaechsteAktionVomBenutzer()
        {
            Console.Write("Bitte gib eine weitere Zahl ein (Fertig zum Beenden): ");
            return Console.ReadLine();
        }

        private double HoleZahlVomBenutzer()
        {
            string zahl;
            Console.Write("Bitte gib eine Zahl für die Berechnung ein: ");
            zahl = Console.ReadLine();

            return Convert.ToDouble(zahl);
        }

        private string HoleOperatorVomBenutzer()
        {
            Console.Write("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
            return Console.ReadLine();
        }

        public void GibResultatAus()
        {
            switch (model.Operation)
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
