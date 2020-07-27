using QR_Code_Scanner.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_Code_Scanner
{
    public partial class App : Application
    {
        private readonly Api api;

        public App()
        {
            InitializeComponent();

            api = new Api();

            MainPage = new MainPage(api);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
