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

        public double TotalWeight => CalculateTotalWeight();

        public double MaxSpeed => CalculateMaxSpeed( Engine.HorsePower, TotalWeight );

        public Car(
            ICarBrand carBrand,
            IBodywork bodyWork,
            IColour colour,
            IEngine engine,
            ITransmission transmission )
        {
            CarBrand = carBrand;
            BodyWork = bodyWork;
            Colour = colour;
            Engine = engine;
            Transmission = transmission;
        }

        // gpt усовершенствовал функцию вычисления скорости, чтобы вес автомобиля тоже учитывался
        private double CalculateMaxSpeed( int horsePower, double weight )
        {
            // Константы
            double horsePowerInWatts = horsePower * 745.7;
            double eta = 0.9;                  // КПД трансмиссии
            double airDensity = 1.225;         // Плотность воздуха (кг/м³)
            double cd = 0.25;                  // Коэффициент аэродинамического сопротивления
            double frontalArea = 2.2;          // Лобовая площадь (м²), если не задана в BodyWork
            double rollingResistanceCoefficient = 0.015; // Коэффициент сопротивления качению (для асфальта)

            // Сила сопротивления качению = weight * g * Crr
            double gravity = 9.81;
            double rollingResistanceForce = weight * gravity * rollingResistanceCoefficient;

            // Уравнение баланса мощностей:
            // P * η = (0.5 * ρ * Cd * A * v³) + (Crr * m * g * v)
            // Решаем численно (метод Ньютона)
            double v = 50; // Начальное предположение (м/с)
            double tolerance = 0.01;
            double delta = 1;

            while ( Math.Abs( delta ) > tolerance )
            {
                double powerAero = 0.5 * airDensity * cd * frontalArea * Math.Pow( v, 3 );
                double powerRolling = rollingResistanceForce * v;
                double totalPowerRequired = powerAero + powerRolling;
                double powerAvailable = horsePowerInWatts * eta;

                // Производная для метода Ньютона: dP/dv = 1.5 * ρ * Cd * A * v² + Crr * m * g
                double derivative = 1.5 * airDensity * cd * frontalArea * Math.Pow( v, 2 ) + rollingResistanceForce;

                delta = ( powerAvailable - totalPowerRequired ) / derivative;
                v += delta;
            }

            return v * 3.6; // Переводим м/с в км/ч
        }

        private double CalculateTotalWeight()
        {
            return BodyWork.Weight + Engine.Weight + Transmission.Weight;
        }

        public override string ToString()
        {
            return $"Марка машины - {CarBrand.Name}" +
                $"\nТип кузова - {BodyWork.Name}" +
                $"\nЦвет - {Colour.Name}" +
                $"\nТрансмиссия - {Transmission.Name}" +
                $"\nДвигатель - {Engine.Name}" +
                $"\nВес машины - {TotalWeight}" +
                $"\nМаксимальная возможная скорось - {MaxSpeed}";
        }
    }
}
