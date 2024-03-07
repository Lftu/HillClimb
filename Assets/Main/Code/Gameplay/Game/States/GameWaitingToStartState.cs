using Main.Code.Audio;
using Main.Code.Core.UI;
using Main.Code.UI;
using Zenject;

namespace Main.Code.Gameplay.Game.States
{
    public class GameWaitingToStartState : GameState
    {
        [Inject] private AudioManager _audioManager;
        [Inject] private HudManager _hudManager;
        private AudioInstance _backgroundMusic;
        public GameWaitingToStartState(GameController gameController) : base(gameController)
        {
            
        }

        protected override void OnStart()
        {
            _backgroundMusic = new AudioInstance(_gameController.View.StartBackgroundMusic, AudioType.Music);
            _audioManager.AssignAudioInstance(_backgroundMusic);
            _backgroundMusic.Play();
            _hudManager.ShowAdditional<StartHudMediator>();
        }

        protected override void OnDispose()
        {
            _backgroundMusic.Stop();
        }
    }
}