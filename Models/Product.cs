namespace dotnet_rest_api.Models;

public class Product {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public Product(string Name, string Description, string ImageUrl) {
        this.Name = Name;
        this.Description = Description;
        this.ImageUrl = ImageUrl.Length > 0 ? ImageUrl : null;
    }
}
