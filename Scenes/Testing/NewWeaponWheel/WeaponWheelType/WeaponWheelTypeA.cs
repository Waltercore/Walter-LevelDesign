using Beta.Projectiles;
using Beta.Projectiles.ProjectileTypes;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelType {

    public class WeaponWheelTypeA : WeaponWheelFunction{

        public override void InitDisplayText() {
            _displayText = "Projektiltyp A";
        }

        public override void Execute(int i) {
            ShootController.SetRightProjectile(ShootController.ProjectileCollection[0]);
        }
    }

}