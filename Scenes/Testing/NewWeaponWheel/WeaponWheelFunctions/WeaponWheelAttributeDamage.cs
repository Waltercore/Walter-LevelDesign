using System;
using Beta.Projectiles;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeDamage : WeaponWheelFunction {

        [SerializeField] private DamageAbility _damageAbility;

        public override void InitDisplayText() {
            _displayText = "Effekt Damage";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_damageAbility);
        }

        
    }

}