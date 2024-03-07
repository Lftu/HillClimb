using Main.Code.Core.UI;
using Main.Code.UI;
using UnityEngine;
using Zenject;

namespace Main.Code.Gameplay.Game.States
{
    public class GameEndedState : GameState
    {
        [Inject] private HudManager _hudManager;
        public GameEndedState(GameController gameController) : base(gameController)
        {
            
        }

        protected override void OnStart()
        {
            _hudManager.ShowAdditional<GameOverHudMediator>();
        }

        protected override void OnDispose()
        {
            
        }
    }
}