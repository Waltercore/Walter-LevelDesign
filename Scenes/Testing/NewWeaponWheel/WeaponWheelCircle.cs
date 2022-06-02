using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.Testing.NewWeaponWheel {

    public class WeaponWheelCircle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        
        public delegate void PointerEnterDelegate();
        public delegate void PointerExitDelegate();
        
        private PointerEnterDelegate _enterDelegate;
        private PointerExitDelegate _exitDelegate;

        public void SetDelegates(PointerEnterDelegate enterDelegate, PointerExitDelegate exitDelegate) {
            _enterDelegate = enterDelegate;
            _exitDelegate = exitDelegate;
        }
        
        public void OnPointerEnter(PointerEventData eventData) => _enterDelegate?.Invoke();

        public void OnPointerExit(PointerEventData eventData) => _exitDelegate?.Invoke();
    }

}