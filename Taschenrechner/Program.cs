using Taschenrechner;

RechnerModel model = new RechnerModel();
ConsoleView view = new ConsoleView(model);
AnwendungsController controller = new AnwendungsController(view, model);

controller.Ausfuehren();