using System;
using NLog;

namespace Taschenrechner
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Taschenrechner gestartet!");

            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView(model);
            AnwendungsController controller = new AnwendungsController(view, model);

            logger.Info("Taschenrechner zusammen gebaut!");

            controller.Ausfuehren();

            logger.Info("Taschenrechner beendet");
        }
    }
}
