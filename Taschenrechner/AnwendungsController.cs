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
            view.HoleEingabenFuerErsteBerechnungVomBenutzer();
            model.Berechne();
            view.GibResultatAus();
            view.HoleEingabenFuerFortlaufendeBerechnung();

            while (!view.BenutzerWillBeenden)
            {
                model.Berechne();
                view.GibResultatAus();
                view.HoleEingabenFuerFortlaufendeBerechnung();
            }
        }
    }
}
