namespace FarmersCreed.Interfaces
{
    using Units;

    public interface IProductProduceable
    {
        int ProductionQuantity { get; set; }

        Product GetProduct();
    }
}
