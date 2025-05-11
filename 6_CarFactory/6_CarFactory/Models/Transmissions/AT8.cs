using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Transmissions
{
    public class AT8 : ITransmission
    {
        public int GearsAmount => 8;

        public double Weight => 80;

        public string Name => "Автоматическа, 8 передач";
    }
}
