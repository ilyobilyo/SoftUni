namespace ReadApiDemo.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool? IsDeleted { get; set; } = false;
    }
}
