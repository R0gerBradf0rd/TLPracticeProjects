namespace Fighters.Models.Races
{
    internal class God : IRace
    {
        public int Damage => int.MaxValue;

        public int Health => int.MaxValue;

        public int Armor => int.MaxValue;
    }
}
