using System;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeSticky : WeaponWheelFunction {

        [SerializeField] private StickyAbility _stickyAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effekt Sticky";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_stickyAbility);
        }
    }

}