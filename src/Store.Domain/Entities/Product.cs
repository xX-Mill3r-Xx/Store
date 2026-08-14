namespace Store.Domain.Entities;

public sealed class Product
{
    private Product()
    {
    }

    public Product(string name, decimal price)
    {
        SetDetails(name, price);
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    public void Update(string name, decimal price) => SetDetails(name, price);

    private void SetDetails(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(name));

        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price), "O preço do produto deve ser maior que zero.");

        Name = name.Trim();
        Price = price;
    }
}
