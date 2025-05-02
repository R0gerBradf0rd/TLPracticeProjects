namespace Fighters.Models.Races
{
    public class RaceFactory
    {
        public static IRace Choose( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Angel();

                case 2:
                    return new Demon();

                case 3:
                    return new Human();

                case 4:
                    return new Ghoul();

                case 5:
                    return new Ork();

                case 6:
                    return new Undead();

                case 7:
                    return new God();

                default:
                    return null;
            }
        }
    }
}