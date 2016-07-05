namespace Taschenrechner
{

    public enum Fehler
    {
        Keiner,
        UngueltigeOperation
    }

    public class RechnerModel
    {
        public double Resultat { get; private set; }
        public double ErsteZahl { get; set; }
        public double ZweiteZahl { get; set; }
        public Fehler AktuellerFehler { get; private set; }

        private string operation = "ungueltig";
        public string Operation
        {
            get
            {
                return operation;
            }

            set
            {
                // Wir ändern den Wert der Eigenschaft nur, wenn ein anderer Wert
                // zugewiesen wird
                if (value != operation)
                {
                    switch (value)
                    {
                        case "+":
                        case "-":
                        case "/":
                        case "*":
                            // Es wurde eine gültige Operation übergeben. Daher können wir
                            // den Fehler zurücksetzen ...
                            if (AktuellerFehler == Fehler.UngueltigeOperation)
                            {
                                AktuellerFehler = Fehler.Keiner;
                            }
                            // ... und den neuen Operator verwenden
                            operation = value;
                            break;

                        default:
                            // Die übergebene Operation wird nicht unterstützt. Daher wird 
                            // angezeigt, dass ein Fehler anliegt und auch die operation zeigt
                            // an, dass etwas nicht stimmt.
                            operation = "ungueltig";
                            AktuellerFehler = Fehler.UngueltigeOperation;
                            break;
                    }
                }
            }
        }

        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
            AktuellerFehler = Fehler.Keiner;
        }

        public void Berechne()
        {
            // Es gab einen Fehler und somit ist das RechnerModel in einem inkonsistenten
            // Zustand. Um Probleme bei der Berechnung zu vermeiden, führen wir sie gar nicht
            // erst aus - defensive Programmierung!
            if (AktuellerFehler != Fehler.Keiner)
            {
                return;
            }

            switch (Operation)
            {
                case "+":
                    Resultat = Addiere(ErsteZahl, ZweiteZahl);
                    break;

                case "-":
                    Resultat = Subtrahiere(ErsteZahl, ZweiteZahl);
                    break;

                case "/":
                    Resultat = Dividiere(ErsteZahl, ZweiteZahl);
                    break;

                case "*":
                    Resultat = Multipliziere(ErsteZahl, ZweiteZahl);
                    break;

                default:
                    AktuellerFehler = Fehler.UngueltigeOperation;
                    break;
            }
        }

        public void FehlerZurueckSetzen()
        {
            AktuellerFehler = Fehler.Keiner;
        }

        private double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;

            return summe;
        }

        private double Subtrahiere(double minuend, double subtrahent)
        {
            double differenz = minuend - subtrahent;

            return differenz;
        }

        private double Dividiere(double dividend, double divisor)
        {
            return dividend / divisor;
        }

        private double Multipliziere(double multiplikator, double multiplikand)
        {
            return multiplikator * multiplikand;
        }
    }
}
