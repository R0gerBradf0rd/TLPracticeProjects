namespace CarFactory.Models.CarBrands
{
    public class Lada : ICarBrand
    {
        public string Name => "Lada";

        public AvilableBrands AvilableBrand => AvilableBrands.Lada;
    }
}
