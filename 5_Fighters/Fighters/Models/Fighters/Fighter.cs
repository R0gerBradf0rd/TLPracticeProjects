using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        private readonly IRace _race;
        private IArmor _armor = new IronArmor();
        private IWeapon _weapon = new Sword();

        private int _currentHealth;
        private int _currentArmor;
        public string Name { get; set; }

        public int Initiative { get; set; }

        public Fighter( string name, IRace race )
        {
            Name = name;
            _race = race;
            Initiative = race.Initiative;

            _currentHealth = GetMaxHealth();
            _currentArmor = CalculateArmor();
        }

        public int GetCurrentHealth() => _currentHealth;

        public int GetMaxHealth() => _race.Health;

        public int CalculateDamage()
        {
            int damage = _weapon.Damage + _race.Damage;

            var random = new Random();

            int randomDamage = random.Next( ( int )( damage * -0.2 ), ( int )( damage * 0.1 ) );

            int criticalDamage = 1;

            // Критический урон, если выпадает 7
            if ( random.Next( 10 ) == 7 )
            {
                criticalDamage = 2;
            }

            return ( ( damage + randomDamage ) * criticalDamage ) * criticalDamage;
        }

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
            Console.WriteLine( $"Текущее Здоровье: {_currentHealth}" );
            Console.WriteLine( $"Текущая Броня: {_currentArmor}\n" );
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

        public void SetName( string name )
        {
            Name = name;
        }
    }
}