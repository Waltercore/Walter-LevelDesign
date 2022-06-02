using System;
using Beta.Projectiles;
using UnityEngine;

namespace Scenes.Testing.NewWeaponWheel {

    [Serializable]
    public abstract class WeaponWheelFunction {

        protected string _displayText;
        public ShootController ShootController { get; set; }

        public abstract void InitDisplayText();
        
        public abstract void Execute(int i);

        public string GetDisplayText() => _displayText;
    }
}