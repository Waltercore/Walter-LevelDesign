using Beta.Projectiles;
using Beta.Projectiles.ProjectileTypes;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelType {

    public class WeaponWheelTypeB : WeaponWheelFunction{

        public override void InitDisplayText() {
            _displayText = "Projektiltyp B";
        }

        public override void Execute(int i) {
            ShootController.SetRightProjectile(ShootController.ProjectileCollection[1]);
        }
    }

}