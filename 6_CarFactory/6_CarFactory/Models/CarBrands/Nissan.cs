namespace CarFactory.Models.CarBrands
{
    public class Nissan : ICarBrand
    {
        public string Name => "Nissan";

        public AvilableBrands AvilableBrand => AvilableBrands.Nissan;
    }
}
