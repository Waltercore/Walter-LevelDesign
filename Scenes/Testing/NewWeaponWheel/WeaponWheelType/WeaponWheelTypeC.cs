using Beta.Projectiles;
using Beta.Projectiles.ProjectileTypes;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelType {

    public class WeaponWheelTypeC : WeaponWheelFunction{
 
        public override void InitDisplayText() {
            _displayText = "Projektiltyp C";
        }

        public override void Execute(int i) {
            ShootController.SetRightProjectile(ShootController.ProjectileCollection[2]);
        }
    }

}