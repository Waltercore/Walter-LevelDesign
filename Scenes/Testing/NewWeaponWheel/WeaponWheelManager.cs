using System;
using System.Collections.Generic;
using Beta.Projectiles;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Scenes.Testing.NewWeaponWheel {

    [Serializable]
    public class WeaponWheelManager : MonoBehaviour {

        [FormerlySerializedAs("_mouseMovedEvent")]
        [Header("Input")] 
        [SerializeField] private InputAction _onMouseMovedEvent;
        
        [FormerlySerializedAs("_mouseClickedEvent")] 
        [SerializeField] private InputAction _onMouseClickedEvent;

        [SerializeField] private InputAction _onActivateCanvas;

        [Space] [Header("Settings")] 
        [SerializeField, Range(2, 20)] private int _partCountInner;
        [SerializeField, Range(2, 20)] private int _partCountOuter;

        [Space][Header("UI References")]
        [SerializeField] private WeaponWheelCircle _innerCircle;
        [SerializeField] private WeaponWheelCircle _outerCircle;
        [SerializeField] private Transform _displayer;
        
        [Space][Header("Separators")]
        [SerializeField] private Transform _separatorParent;
        [SerializeField] private GameObject _separatorPrefabInner;
        [SerializeField] private GameObject _separatorPrefabOuter;
        private List<GameObject> _separatorsInner;
        private List<GameObject> _separatorsOuter;

        [Space] [Header("DisplayTexts")] 
        [SerializeField] private Transform _displayTextParent;
        [SerializeField] private GameObject _displayTextPrefabInnerUp;
        [SerializeField] private GameObject _displayTextPrefabInnerDown;
        [SerializeField] private GameObject _displayTextPrefabOuterUp;
        [SerializeField] private GameObject _displayTextPrefabOuterDown;
        private List<GameObject> _functionDisplaysInner;
        private List<GameObject> _functionDisplaysOuter;

        [Space] [Header("Functions")] [SerializeField]
        private Canvas _canvas;
        [SerializeField] private ShootController _shootController;
        [SerializeReference, SerializeReferenceButton] private List<WeaponWheelFunction> _innerFunctions;
        [SerializeReference, SerializeReferenceButton] private List<WeaponWheelFunction> _outerFunctions;

        private bool _hoverInner;
        private bool _hoverOuter;
        
        private void Awake() {
            _innerCircle.SetDelegates(EnterInner, ExitInner);
            _outerCircle.SetDelegates(EnterOuter, null);

            _innerFunctions.Reverse();
            _outerFunctions.Reverse();
            
            UpdateSeparators(true);
            UpdateSeparators(false);
            SetPropertyOnWeaponWheelTypes();
        }

        private void SetPropertyOnWeaponWheelTypes() {
            foreach (var innerFunction in _innerFunctions) {
                innerFunction.ShootController = _shootController;
            }

            foreach (var outerFunction in _outerFunctions) {
                outerFunction.ShootController = _shootController;
            }
        }

        private void OnEnable() {
            _onMouseMovedEvent.Enable();
            _onMouseClickedEvent.Enable();
            _onActivateCanvas.Enable();
            _onMouseMovedEvent.performed += OnOnMouseMoved;
            _onMouseClickedEvent.performed += OnOnMouseClicked;
            _onActivateCanvas.performed += OnCanvasActivate;
        }

        private void OnDisable() {
            _onMouseMovedEvent.Disable();
            _onMouseClickedEvent.Disable();
            _onActivateCanvas.Disable();
            _onMouseMovedEvent.performed -= OnOnMouseMoved;
            _onMouseClickedEvent.performed -= OnOnMouseClicked;
            _onActivateCanvas.performed -= OnCanvasActivate;
        }

        private void OnCanvasActivate(InputAction.CallbackContext obj) {
            _canvas.enabled = !_canvas.enabled;
        }

        private void OnOnMouseClicked(InputAction.CallbackContext context) {
            if (_hoverInner) {
                float currentAngle = _displayer.transform.localRotation.eulerAngles.z;
                float step = (float)360 / _partCountInner;

                float trueStep = 0f;
                int stepIndex = 0;
                while (trueStep < currentAngle) {
                    trueStep += step;
                    stepIndex++;
                }
                
                _innerFunctions[stepIndex - 1].Execute(stepIndex - 1);
            }

            if (_hoverOuter) {
                float currentAngle = _displayer.transform.localRotation.eulerAngles.z;
                float step = (float)360 / _partCountOuter;

                float trueStep = 0f;
                int stepIndex = 0;
                while (trueStep < currentAngle) {
                    trueStep += step;
                    stepIndex++;
                }
                
                _outerFunctions[stepIndex - 1].Execute(stepIndex - 1);
            }
        }

        private void OnOnMouseMoved(InputAction.CallbackContext context) {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            _displayer.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - _displayer.position);
        }

        private void UpdateSeparators(bool inner) {
            
            if (_separatorParent == null) return;
            if (_separatorPrefabInner == null) return;
            if (_separatorPrefabOuter == null) return;

            float count = inner ? _partCountInner : _partCountOuter;
            float anglePerPart = 360 / count;

            float trueAngle = 0;

            if (inner) _separatorsInner = new List<GameObject>();
            else _separatorsOuter = new List<GameObject>();
            
            for (int i = 0; i < count; i++) {
                GameObject separator = Instantiate(inner ? _separatorPrefabInner : _separatorPrefabOuter, _separatorParent);
                separator.transform.localRotation = Quaternion.Euler(new Vector3(0,0, trueAngle));

                GameObject displayText = Instantiate(inner ? _displayTextPrefabInnerUp : _displayTextPrefabOuterUp, _displayTextParent);
                displayText.transform.localRotation = Quaternion.Euler(new Vector3(0,0,trueAngle + anglePerPart / 2));

                if (inner) _innerFunctions[i].InitDisplayText();
                else _outerFunctions[i].InitDisplayText();
                
                displayText.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = inner ? _innerFunctions[i].GetDisplayText() : _outerFunctions[i].GetDisplayText();

                if (inner) _separatorsInner.Add(separator);
                else _separatorsOuter.Add(separator);
                
                trueAngle += anglePerPart;
            }
        }

        private void EnterInner() {
            _hoverInner = true;
            _hoverOuter = false;
        }
        private void ExitInner() => _hoverInner = false;
        private void EnterOuter() => _hoverOuter = true;
    }

}