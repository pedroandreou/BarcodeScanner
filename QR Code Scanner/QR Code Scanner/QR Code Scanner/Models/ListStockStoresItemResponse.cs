using System;
using System.Collections.Generic;
using System.Text;

namespace QR_Code_Scanner.Models
{
    public class ApiResponse
    {
        public string response_code { get; set; }
        public string response_msg { get; set; }
        public string response_id { get; set; }
    }
    
    public class ListStockStoresItemResponse
    {
        public ApiResponse api_response { get; set; } 
        public StockStoresItem[] list_stock_stores_item { get; set; }
    }
}
