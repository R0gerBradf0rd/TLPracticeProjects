using CarFactory.Models.Bodyworks;
using CarFactory.Models.CarBrands;
using CarFactory.Models.Colours;
using CarFactory.Models.Engiens;
using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Car
{
    public interface ICar
    {
        ICarBrand CarBrand { get; }

        IBodywork BodyWork { get; }

        IColour Colour { get; }

        IEngine Engine { get; }

        ITransmission Transmission { get; }

        double MaxSpeed { get; }

        double TotalWeight { get; }

        public string ToString();
    }
}
