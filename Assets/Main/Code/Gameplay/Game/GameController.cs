using System;
using Main.Code.Configs;
using Main.Code.Core.State;
using Main.Code.Gameplay.Game.States;
using Main.Code.Gameplay.Game.Car;
using Zenject;

namespace Main.Code.Gameplay.Game
{
    public sealed class GameController : IDisposable
    {
        [Inject] private GameConfig _gameConfig;
        [Inject]private GameView _gameView;
        private StateController _stateController;
        private GameModel _gameModel;
        
        public Car.Car Car { get; set; }
        public GameModel Model => _gameModel;
        public GameView View => _gameView;
        
        public GameController()
        {
            _gameModel = new GameModel(_gameConfig);
        }
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _stateController = new StateController();
            diContainer.Inject(_stateController);
            _stateController.AddState(new GameWaitingToStartState(this));
            _stateController.AddState(new GameEndedState(this));
            _stateController.AddState(new GameStartedState(this));
            _stateController.AddState(new GameInitializeState(this));
            ChangeState<GameWaitingToStartState>();
        }

        public void ChangeState<T>() where T : GameState
        {
            _stateController.ChangeState<T>();
        }

        public void Dispose()
        {
        }

        public void Play()
        {
            ChangeState<GameInitializeState>();
        }

        public void Lose()
        {
            ChangeState<GameEndedState>();
        }
    }
}