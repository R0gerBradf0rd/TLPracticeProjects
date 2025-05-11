using CarFactory.Models.Engiens;

namespace CarFactory.Models.Engines
{
    public class V10 : IEngine
    {
        public int HorsePower => 800;

        public double Weight => 350;

        public string Name => "V10";
    }
}
