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
        private const string BasePath = "https://api.powersoft365.com/test_connection";

        private static readonly HttpClient client = new HttpClient();

        public Api()
        {
            
        }

        public async Task<bool> TestConnection()
        {
            var response = await client.GetAsync(this.GetPath("/test_connection"));
            var resp = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        private string GetPath(string path)
        {
            return Path.Combine(BasePath, path);
        }
    }
}
