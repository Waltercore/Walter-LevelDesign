using System;
using Beta.Projectiles;
using Beta.Projectiles.ProjectileAbilities;
using Beta.Projectiles.ProjectileTypes;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel.WeaponWheelFunctions {

    [Serializable]
    public class WeaponWheelAttributeExplosion : WeaponWheelFunction {

        [SerializeField] private ExplosionAbility _explosionAbility;
        
        public override void InitDisplayText() {
            _displayText = "Effekt Explosion";
        }

        public override void Execute(int i) {
            ShootController.SetRightAbility(_explosionAbility);
        }

        
    }

}