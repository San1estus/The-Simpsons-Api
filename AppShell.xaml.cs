namespace TheSimpsons
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.DetallePage), typeof(Pages.DetallePage));
        }
    }
}
