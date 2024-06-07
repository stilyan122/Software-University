namespace ProductsApi.Data
{
    public class Product
    {
        public int Id { get; init; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
