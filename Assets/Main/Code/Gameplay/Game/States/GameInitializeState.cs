using Main.Code.Audio;
using Main.Code.Core;
using Main.Code.Core.UI;
using Main.Code.UI;
using UnityEngine;
using Zenject;
using AudioType = Main.Code.Audio.AudioType;

namespace Main.Code.Gameplay.Game.States
{
    public class GameInitializeState : GameState
    {
        [Inject] private HudManager _hudManager;
        [Inject] private AudioManager _audioManager;
        [Inject] private CameraControl _cameraControl;
        [Inject] private DiContainer _diContainer;
        
        private AudioInstance _backgroundMusic;
        public GameInitializeState(GameController gameController) : base(gameController)
        {
        }

        protected override void OnStart()
        {
            
            _gameController.View.gameObject.SetActive(true);

             _gameController.Car = _diContainer.InstantiatePrefab(_gameController.View.Player, 
                 _gameController.View.CarSpawnPosition.position, 
                 Quaternion.identity,
                 _gameController.View.transform).GetComponent<Car.Car>();
             
            _hudManager.ShowAdditional<GameHudMediator>();
            _gameController.ChangeState<GameStartedState>();
            _cameraControl.AssignCamera(_gameController.Car.transform);
            
            _backgroundMusic = new AudioInstance(_gameController.View.GameBackgroundMusic, AudioType.Music);
            _audioManager.AssignAudioInstance(_backgroundMusic);
            _backgroundMusic.Play();
        }

        protected override void OnDispose()
        {
        }
    }
}