namespace CarFactory.Models.CarBrands
{
    public class Toyota : ICarBrand
    {
        public string Name => "Toyota";

        public AvilableBrands AvilableBrand => AvilableBrands.Toyota;
    }
}
