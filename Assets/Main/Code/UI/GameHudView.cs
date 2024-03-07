using Main.Code.Core.UI;
using Main.Code.UI.Additional;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Main.Code.UI
{
    public sealed class GameHudView : BaseHud
    {
        [SerializeField] private EventTrigger _gasButton;
        [SerializeField] private EventTrigger _brakeButton;
        [SerializeField] private ToggleView _gasToggle;
        [SerializeField] private ToggleView _brakeToggle;
        [SerializeField] private Slider _fuelSlider;
        [SerializeField] private GameObject _lowFuel;
        [SerializeField] private CoinsView _coinsView;
        public EventTrigger GasButton => _gasButton;
        public EventTrigger BrakeButton => _brakeButton;
        public ToggleView GasToggle => _gasToggle;
        public ToggleView BrakeToggle => _brakeToggle;
        public Slider FuelSlider => _fuelSlider;
        public GameObject LowFuel => _lowFuel;
        public CoinsView CoinsView => _coinsView;
        protected override void OnEnable()
        {
            
        }

        protected override void OnDisable()
        {
            
        }
    }
}