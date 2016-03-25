namespace FarmersCreed
{
    using Units;

    public interface IProduct
    {
        ProductType ProductType { get; set; }

        int Quantity { get; set; }
    }
}
