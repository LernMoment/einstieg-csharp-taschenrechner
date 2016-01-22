using System;

namespace Taschenrechner
{
    class AnwendungsController
    {
        private ConsoleView view;
        private RechnerModel model;

        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Ausfuehren()
        {
            string ersteZahlAlsString = view.HoleZahlVomBenutzer();
            string operation = view.HoleOperatorVomBenutzer();
            string zweiteZahlAlsString = view.HoleZahlVomBenutzer();

            // Wandel Text in Gleikommazahlen
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist.
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            model.Berechne(ersteZahl, zweiteZahl, operation);

            // Ausgabe
            view.GibResultatAus(operation);
            view.WarteAufEndeDurchBenutzer();
        }
    }
}
