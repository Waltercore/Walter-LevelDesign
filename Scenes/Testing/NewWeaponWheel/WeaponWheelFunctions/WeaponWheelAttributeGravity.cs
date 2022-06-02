using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeGravity : WeaponWheelFunction {

        [SerializeField] private GravityAbility _gravityAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effekt Gravity";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_gravityAbility);
        }
    }

}