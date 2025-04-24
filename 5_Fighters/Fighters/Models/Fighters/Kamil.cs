using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Kamil : IFighter
    {
        private readonly IRace _race;
        private IArmor _armor = new DimondArmor();
        private IWeapon _weapon = new LaserGun();

        private int _currentHealth;
        private int _currentArmor;

        public string Name { get; private set; }

        public Kamil( string name, IRace race )
        {
            Name = name;
            _race = race;

            _currentHealth = GetMaxHealth();
            _currentArmor = CalculateArmor();
        }

        public int GetCurrentHealth() => _currentHealth;

        public int GetMaxHealth() => _race.Health;

        public int CalculateDamage() => _weapon.Damage + _race.Damage;

        public int CalculateArmor() => _armor.Armor + _race.Armor;

        public void SetArmor( IArmor armor )
        {
            _armor = armor;
        }

        public void SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
        }

        public void ShowCurrentHealthAndArmor()
        {
            Console.WriteLine( $"Current Health: {_currentHealth}" );
            Console.WriteLine( $"Current Armor: {_currentArmor}" );
        }

        public void TakeDamage( int damage )
        {
            int newHealth = _currentHealth;
            int newArmor = _currentArmor;
            if ( _currentArmor > 0 )
            {
                newArmor = _currentArmor - damage;
            }
            if ( _currentHealth > 0 && _currentArmor == 0 )
            {
                newHealth = _currentHealth - damage;
            }
            if ( newArmor < 0 )
            {
                newHealth = _currentHealth + newArmor;
                newArmor = 0;
            }
            if ( newHealth < 0 )
            {
                newHealth = 0;
            }

            _currentHealth = newHealth;
            _currentArmor = newArmor;
        }
    }
}