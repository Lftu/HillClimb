using System;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Code.UI.Additional
{
    public class ToggleView : MonoBehaviour
    {
        [SerializeField] private Sprite _toggleOn, _togleOff;
        [SerializeField] private Image _sp;
    
        private bool _isOn;
        public bool IsOn => _isOn;
        public Action OnSwitch;

        void Start()
        {
            GetComponent<Button>()?.onClick.AddListener(Switch);
            Sunc();
        }

        private void Switch()
        {
            _isOn = !_isOn;
            OnSwitch?.Invoke();
            Sunc();
        }
        public void Change(bool state)
        {
            _isOn = state;
            Sunc();
        }
        private void Sunc()
        {
            _sp.sprite = _isOn ? _toggleOn : _togleOff;
        }
    }
}