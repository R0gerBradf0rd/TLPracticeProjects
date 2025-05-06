namespace Fighters.Models.Races
{
    internal class Ghoul : IRace
    {
        public int Damage => 1000 - 7;

        public int Health => 1000 - 7;

        public int Armor => 1000 - 7;

        public int Initiative => 1000 - 7;
    }
}
