using Microsoft.UI.Xaml;
using MauiPiskvorky;  // ← přidej tento řádek

namespace piškvorky.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}