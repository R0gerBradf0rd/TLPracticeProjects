using CarFactory.Models.Car;

namespace CarFactory
{
    public static class CarConfiguration
    {
        public static string GetCarConfiguration( ICar car )
        {
            return $"Марка машины - {car.CarBrand.Name}" +
                $"\nТип кузова - {car.BodyWork.Name}" +
                $"\nЦвет - {car.Colour.Name}" +
                $"\nТрансмиссия - {car.Transmission.Name}" +
                $"\nДвигатель - {car.Engine.Name}" +
                $"\nВес машины - {car.TotalWeight}" +
                $"\nМаксимальная возможная скорось - {car.MaxSpeed}";
        }
    }
}
