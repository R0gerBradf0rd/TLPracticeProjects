namespace CarFactory.Models.CarBrands
{
    public interface ICarBrand
    {
        string Name { get; }

        Brand AvilableBrand { get; }
    }
}
