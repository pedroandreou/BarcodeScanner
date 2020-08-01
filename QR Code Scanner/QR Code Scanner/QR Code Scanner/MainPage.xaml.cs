using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using QR_Code_Scanner;
using QR_Code_Scanner.Services;
using Xamarin.Forms.Internals;

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

                var items = await this.api.ListStockStoresItem(txtBarcode.Text);

                if (items.Length == 0)
                {
                    Console.WriteLine("No items found!");
                    return;
                }

                items.ToList().ForEach(item =>
                {
                    // Print all items u want here
                    Console.WriteLine("Item name", item.item_name);
                   // etsi apla dame kame print oula ta props p thelis so item name, stock, item code, store name
                   //let me try one

                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
