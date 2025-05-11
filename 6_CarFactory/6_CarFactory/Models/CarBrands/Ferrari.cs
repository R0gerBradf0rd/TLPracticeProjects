namespace CarFactory.Models.CarBrands
{
    public class Ferrari : ICarBrand
    {
        public string Name => "Ferrari";

        public AvilableBrands AvilableBrand => AvilableBrands.Ferrari;
    }
}
