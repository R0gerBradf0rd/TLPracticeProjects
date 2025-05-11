using CarFactory.Models.Engiens;

namespace CarFactory.Models.Engines
{
    public static class EngineFactory
    {
        public static IEngine GetEngine( int number )
        {
            switch ( number )
            {
                case 1:
                    return new V4();

                case 2:
                    return new V8();

                case 3:
                    return new V10();

                default:
                    return null;
            }
        }

        public static string GetEnginesDescription()
        {
            return "Выберите двигатель:" +
                "\n1 - V4 {150 лошадиных сил}" +
                "\n2 - V8 {600 лошадиных сил}" +
                "\n3 - V10 {800 лошадиных сил}";
        }
    }
}