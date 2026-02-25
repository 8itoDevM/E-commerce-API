namespace fakeshop.API.Models.Domain {
    public class Product {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProductImageUrl { get; set; }
        public Guid VendorId { get; set; }

        public Vendor Vendor { get; set; }
    }
}
