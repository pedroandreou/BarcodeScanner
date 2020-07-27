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
            var items = await this.api.ListStockStoresItem("A-B-C-AZURE-340");
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();

                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
