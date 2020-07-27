using Flurl;
using Flurl.Http;
using QR_Code_Scanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QR_Code_Scanner.Services
{
    public class Api
    {
        private const string BasePath = "https://api.powersoft365.com";

        private const string Token = "12830.E26C6F00-C7CF-430D-B99F-ADB3D61696E9.001.7777";

        public async Task<bool> TestConnection()
        {
            var path = this.GetPath("/test_connection");
            var response = await path.GetAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task<StockStoresItem[]> ListStockStoresItem(string itemCode)
        {
            var path = this.GetPath("/list_stock_stores_item");

            try
            {
                var response = await path.SetQueryParams(new
                {
                    token = Token,
                    item_code_365 = itemCode
                }).GetJsonAsync<ListStockStoresItemResponse>();

                if (response.api_response.response_code != "1")
                {
                    throw new Exception(response.api_response.response_msg);
                }

                return response.list_stock_stores_item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string GetPath(string path)
        {
            return Url.Combine(BasePath, path);
        }
    }
}
