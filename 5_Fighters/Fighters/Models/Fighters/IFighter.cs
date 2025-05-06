using Fighters.Models.Armors;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }

        int Initiative { get; }
        int GetCurrentHealth();
        int GetMaxHealth();
        int CalculateDamage();
        int CalculateArmor();
        void SetArmor( IArmor armor );
        void SetWeapon( IWeapon weapon );

        void SetName( string name );
        void TakeDamage( int damage );
        void ShowCurrentHealthAndArmor();
    }
}
