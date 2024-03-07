using Main.Code.Core.State;

namespace Main.Code.Gameplay.Game.States
{
    public abstract class GameState : State
    {
        protected GameController _gameController;

        public GameState(GameController gameController)
        {
            _gameController = gameController;
        }
    }
}