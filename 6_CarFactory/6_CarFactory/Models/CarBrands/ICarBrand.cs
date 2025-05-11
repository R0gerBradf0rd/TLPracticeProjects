namespace CarFactory.Models.CarBrands
{
    public interface ICarBrand
    {
        string Name { get; }

        AvilableBrands AvilableBrand { get; }
    }
}
