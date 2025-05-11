using CarFactory.Models.Bodyworks;
using CarFactory.Models.CarBrands;
using CarFactory.Models.Colours;
using CarFactory.Models.Engiens;
using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Car
{
    public class Car : ICar
    {
        public ICarBrand CarBrand { get; }

        public IBodywork BodyWork { get; }

        public IColour Colour { get; }

        public IEngine Engine { get; }

        public ITransmission Transmission { get; }

        public Car( ICarBrand carBrand, IBodywork bodyWork, IColour colour, IEngine engine, ITransmission transmission )
        {
            CarBrand = carBrand;
            BodyWork = bodyWork;
            Colour = colour;
            Engine = engine;
            Transmission = transmission;
        }

        public double TotalWeight => CalculateTotalWeight();

        public double MaxSpeed => CalculateMaxSpeed( Engine.HorsePower, TotalWeight );

        private double CalculateMaxSpeed( int horsePower, double weight )
        {
            // Нашел какую-то формулу
            double horsePowerInWatts = horsePower * 745.7;
            double eta = 0.9;
            double airDensity = 1.225;
            double coefficientOfAerodynamicDrag = 0.25; // усреднеенное значение
            double maxSpeed = ( 2 * horsePowerInWatts * eta ) / ( airDensity * coefficientOfAerodynamicDrag * BodyWork.FrontalArea );
            return Math.Cbrt( maxSpeed ) + 100; // +100 чисто потому, что маловата скорось получается, а в физике рыться не охота)
        }

        private double CalculateTotalWeight()
        {
            return BodyWork.Weight + Engine.Weight + Transmission.Weight;
        }
    }
}
