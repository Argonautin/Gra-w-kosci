using Microsoft.Extensions.DependencyInjection;

namespace Kosci
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell()) {Width = 800, Height = 600};
            return window;
        }
    }
}