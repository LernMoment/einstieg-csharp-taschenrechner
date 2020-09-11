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
            while (!view.BenutzerWillBeenden)
            {
                if(view.BenutzerWillNeuRechnen)
                {
                    view.HoleEingabenFuerErsteBerechnungVomBenutzer();
                }
                model.Berechne();
                view.GibResultatAus();
                view.HoleEingabenFuerFortlaufendeBerechnung();
            }
        }
    }
}
