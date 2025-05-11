using CarFactory.Models.Engiens;

namespace CarFactory.Models.Engines
{
    public class V8 : IEngine
    {
        public int HorsePower => 600;

        public double Weight => 300;

        public string Name => "V8";
    }
}
