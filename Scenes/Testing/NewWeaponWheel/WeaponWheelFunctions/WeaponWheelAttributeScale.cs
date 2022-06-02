using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeScale : WeaponWheelFunction {

        [SerializeField] private ScaleAbility _scaleAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effect Scale";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_scaleAbility);
        }
    }

}