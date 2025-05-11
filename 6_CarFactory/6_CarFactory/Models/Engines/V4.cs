using CarFactory.Models.Engiens;

namespace CarFactory.Models.Engines
{
    public class V4 : IEngine
    {
        public int HorsePower => 200;

        public double Weight => 150;

        public string Name => "V4";
    }
}
