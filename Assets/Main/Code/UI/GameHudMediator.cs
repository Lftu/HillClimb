using Core.UI;
using Main.Code.Core.Additional;
using Main.Code.Gameplay.Game;
using UnityEngine.EventSystems;
using Zenject;

namespace Main.Code.UI
{
    public sealed class GameHudMediator : Mediator<GameHudView>
    {
        [Inject] private GameController _gameController;
        [Inject] private Bank _bank;
        private EventTrigger.Entry _gasDown, _gasUp, _brakeDown, _brakeUp;
        protected override void Show()
        {
            _gasDown = new EventTrigger.Entry();
            _gasDown.eventID = EventTriggerType.PointerDown;
            _gasDown.callback.AddListener((eventData) => { StartGas(); });

            _gasUp = new EventTrigger.Entry();
            _gasUp.eventID = EventTriggerType.PointerUp;
            _gasUp.callback.AddListener((eventData) => { StopGas(); });
            
            _brakeDown = new EventTrigger.Entry();
            _brakeDown.eventID = EventTriggerType.PointerDown;
            _brakeDown.callback.AddListener((eventData) => { StartBrake(); });

            _brakeUp = new EventTrigger.Entry();
            _brakeUp.eventID = EventTriggerType.PointerUp;
            _brakeUp.callback.AddListener((eventData) => { StopBrake(); });
            
            _view.GasButton.triggers.Add(_gasDown);
            _view.GasButton.triggers.Add(_gasUp);
            
            _view.BrakeButton.triggers.Add(_brakeDown);
            _view.BrakeButton.triggers.Add(_brakeUp);

            _gameController.Car.OnFuelChange += ChangeSliderValue;
            _view.CoinsView.Initialize(_bank);
        }

        protected override void Hide()
        {
            _view.GasButton.triggers.Remove(_gasDown);
            _view.GasButton.triggers.Remove(_gasUp);
            
            _view.BrakeButton.triggers.Remove(_brakeDown);
            _view.BrakeButton.triggers.Remove(_brakeUp);
            
            _gameController.Car.OnFuelChange -= ChangeSliderValue;
            _view.CoinsView.Dispose();
        }

        private void ChangeSliderValue(float value)
        {
            _view.FuelSlider.value = value / 100;
            _view.LowFuel.SetActive(value < 15f);
        }

        private void StartGas()
        {
            _view.GasToggle.Change(true);
            _gameController.Car.GasDown();
        }
        
        private void StopGas()
        {
            _view.GasToggle.Change(false);
            _gameController.Car.GasUp();
        }
        
        private void StartBrake()
        {
            _view.BrakeToggle.Change(true);
            _gameController.Car.BrakeDown();
        }
        
        private void StopBrake()
        {
            _view.BrakeToggle.Change(false);
            _gameController.Car.BrakeUp();
        }
        
    }
}