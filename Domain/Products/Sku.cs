namespace Domain.Products;

public record Sku
{
    private const int SkuMaxLength = 15;
    private Sku(string value) => Value = value;
    public string Value { get; init; }
    public static Sku? Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (value.Length > SkuMaxLength)
        {
            return null;
        }

        return new Sku(value);
    }
}
