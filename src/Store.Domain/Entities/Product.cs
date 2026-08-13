namespace Store.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "O nome do produto é obrigatório.",
                    nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(price),
                        "O preço do produto deve ser maior que zero.");
            }

            Id = id;
            Name = name.Trim();
            Price = price;
        }
    }
}
