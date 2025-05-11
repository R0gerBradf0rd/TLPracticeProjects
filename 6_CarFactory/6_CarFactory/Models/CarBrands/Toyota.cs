namespace CarFactory.Models.CarBrands
{
    public class Toyota : ICarBrand
    {
        public string Name => "Toyota";

        public Brand AvilableBrand => Brand.Toyota;
    }
}
