using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using QR_Code_Scanner;
using QR_Code_Scanner.Services;

namespace QR_Code_Scanner
{
    public partial class MainPage : ContentPage
    {
        private readonly Api api;

        public MainPage(Api api)
        {
            this.api = api;
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }

                var ok = await this.api.TestConnection();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
