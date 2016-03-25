namespace FarmersCreed.Interfaces
{
    using Units;

    public interface IEdible : IProduct 
    {
        FoodType FoodType { get; set; }

        int HealthEffect { get; set; }
    }
}
