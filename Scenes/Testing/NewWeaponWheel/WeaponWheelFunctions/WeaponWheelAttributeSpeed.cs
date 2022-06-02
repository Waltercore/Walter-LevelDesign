using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeSpeed : WeaponWheelFunction {

        [SerializeField] private SpeedAbility _speedAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effect Speed";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_speedAbility);
        }
    }

}