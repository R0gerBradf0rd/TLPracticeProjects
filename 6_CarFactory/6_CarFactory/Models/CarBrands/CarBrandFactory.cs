namespace CarFactory.Models.CarBrands
{
    public static class CarBrandFactory
    {
        public static ICarBrand GetCarBrand( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Ferrari();

                case 2:
                    return new Lamborghini();

                case 3:
                    return new Lada();

                case 4:
                    return new Nissan();

                case 5:
                    return new Toyota();

                default:
                    return null;
            }
        }

        public static string GetCarBrandDescription()
        {
            return "Выберите марку машины:" +
                "\n1 - Ferrari" +
                "\n2 - Lamborghini" +
                "\n3 - Lada" +
                "\n4 - Nissan" +
                "\n5 - Toyota";
        }
    }
}
