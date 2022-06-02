using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeAoe : WeaponWheelFunction {

        [SerializeField] private AOEAbility _aoeAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effekt Aoe";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_aoeAbility);
        }
    }

}