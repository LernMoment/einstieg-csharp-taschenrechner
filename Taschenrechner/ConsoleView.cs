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
            // TODO: Refactoring benötigt - Probleme: unübersichtlich, nicht DRY, nicht SLA!

            // Eingabe und Validierung der ersten Zahl
            do
            {
                model.ErsteZahl = HoleZahlVomBenutzer();
                if (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung)
                {
                    Console.WriteLine("FEHLER: Zahl muss größer als {0} und kleiner als {1} sein.", RechnerModel.UntererGrenzwert, RechnerModel.ObererGrenzwert);
                }
            }
            while (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung);

            // Eingabe und Validierung des Operators
            model.Operation = HoleOperatorVomBenutzer();

            // Eingabe und Validierung der zweiten Zahl
            do
            {
                model.ZweiteZahl = HoleZahlVomBenutzer();
                if (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung)
                {
                    Console.WriteLine("FEHLER: Zahl muss größer als {0} und kleiner als {1} sein.", RechnerModel.UntererGrenzwert, RechnerModel.ObererGrenzwert);
                }
            }
            while (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung);
        }

        public void HoleEingabenFuerFortlaufendeBerechnung()
        {
            string eingabe = HoleNaechsteAktionVomBenutzer();

            if (eingabe.ToUpper() == "FERTIG" || eingabe == "")
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
            Console.Write("Bitte gib eine weitere Zahl ein (FERTIG zum Beenden): ");
            return Console.ReadLine();
        }

        private double HoleZahlVomBenutzer()
        {
            string eingabe;
            double zahl;
            Console.Write("Bitte gib eine Zahl für die Berechnung ein: ");
            eingabe = Console.ReadLine();

            while (!double.TryParse(eingabe, out zahl))
            {
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben!");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden.");
                Console.WriteLine("Der . fungiert als Trennzeichen an Tausenderstellen.");
                Console.WriteLine("Das , ist das Trennzeichen für die Nachkommastellen.");
                Console.WriteLine("Alle drei Sonderzeichen sind optional!");
                Console.WriteLine();
                Console.Write("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
            }

            return zahl;
        }

        private string HoleOperatorVomBenutzer()
        {
            string operation;

            do
            {
                Console.Write("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
                operation = Console.ReadLine();
                model.Operation = operation;

                if (model.AktuellerFehler == Fehler.UngueltigeOperation)
                {
                    Console.WriteLine("FEHLER: Die eingegebene Operation wird nicht unterstützt.");
                }
            }
            while (model.AktuellerFehler == Fehler.UngueltigeOperation);

            return operation;
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
