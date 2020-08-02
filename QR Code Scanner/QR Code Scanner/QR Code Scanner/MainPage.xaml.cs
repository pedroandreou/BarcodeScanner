using System;
using System.Collections.Generic;
using Xamarin.Forms;
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

                var barCode = await scanner.ScanAsync();
                if (String.IsNullOrEmpty(barCode))
                {
                    return;
                }

                var items = await this.api.ListStockStoresItem(barCode);

                if (items.Length == 0)
                {
                    Console.WriteLine("No items found!");
                    return;
                }

                StockStoresItemsView.ItemsSource = items;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
