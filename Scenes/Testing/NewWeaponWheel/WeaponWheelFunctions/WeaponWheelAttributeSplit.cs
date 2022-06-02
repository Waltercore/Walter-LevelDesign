using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeSplit : WeaponWheelFunction {

        [SerializeField] private SplitAbility _splitAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effekt Split";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_splitAbility);
        }
    }

}