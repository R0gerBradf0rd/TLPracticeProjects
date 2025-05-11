namespace CarFactory.Models.Bodyworks
{
    public static class BodyworkFactory
    {
        public static IBodywork GetBodywork( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Sedan();

                case 2:
                    return new Hatchback();

                case 3:
                    return new Sport();

                case 4:
                    return new SUV();

                case 5:
                    return new Carcas();

                default:
                    return null;
            }
        }

        public static string GetBodyworkDescription()
        {
            return "Выберите тип кузова:" +
                "\n1 - Седан" +
                "\n2 - Хетчбэк" +
                "\n3 - Спортивный" +
                "\n4 - Внедорожник" +
                "\n5 - Каркасный";
        }
    }
}
