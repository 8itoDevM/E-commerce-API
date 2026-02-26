namespace fakeshop.API.Models.DTO {
    public class ProductDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProductImageUrl { get; set; }
        public Guid VendorId { get; set; }
    }
}
