namespace Fighters.Models.Races
{
    internal class Ork : IRace
    {
        public int Damage => 10;

        public int Health => 150;

        public int Armor => 30;

        public int Initiative => 50;
    }
}
