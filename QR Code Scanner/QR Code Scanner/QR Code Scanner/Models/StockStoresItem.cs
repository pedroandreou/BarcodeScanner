namespace QR_Code_Scanner.Models
{
    public class StockStoresItem
    {
        public string store_code_365 { get; set; }
        public string store_name { get; set; }
        public bool store_active { get; set; }
        public string item_code_365 { get; set; }
        public string model_code_365 { get; set; }
        public string item_name { get; set; }
        public int stock { get; set; }
        public int stock_on_transfer { get; set; }
        public int stock_reserved { get; set; }
        public int stock_ordered { get; set; }
        public int minimum_stock { get; set; }
        public int required_stock { get; set; }
    }
}
