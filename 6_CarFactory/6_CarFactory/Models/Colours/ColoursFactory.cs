using System.Reflection.Emit;

namespace CarFactory.Models.Colours
{
    public static class ColoursFactory
    {
        public static IColour GetColour( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Black();

                case 2:
                    return new White();

                case 3:
                    return new Green();

                case 4:
                    return new Blue();

                case 5:
                    return new Red();

                default:
                    return null;
            }
        }

        public static string GetColourDescription()
        {
            return "Выберите цвет машины:" +
                "\n1 - Черный" +
                "\n2 - Белый" +
                "\n3 - Зеленый" +
                "\n4 - Синий" +
                "\n5 - Красный";
        }
    }
}
