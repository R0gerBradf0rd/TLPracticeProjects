namespace Fighters.Models.Races
{
    internal class Undead : IRace
    {
        public int Damage => 10;

        public int Health => 110;

        public int Armor => 0;

        public int Initiative => 60;
    }
}
