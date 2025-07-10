using CarlosMoreta_Examenprogra.Repository;

namespace CarlosMoreta_Examenprogra
{
    public partial class App : Application
    {
        public static ProductoRepository ProductoRepo { get; private set; }
        public static LogService LogServicio { get; private set; }

        public App(ProductoRepository repo, LogService logService)
        {
            InitializeComponent();

            ProductoRepo = repo;
            LogServicio = logService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
