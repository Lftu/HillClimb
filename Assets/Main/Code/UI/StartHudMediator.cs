using Core.UI;
using Main.Code.Audio;
using Main.Code.Core.Additional;
using Main.Code.Core.UI;
using Main.Code.Extentions;
using Main.Code.Gameplay.Game;
using Zenject;

namespace Main.Code.UI
{
    public sealed class StartHudMediator : Mediator<StartHudView>
    {
        [Inject] private GameController _gameController;
        [Inject] private AudioManager _audioManager;
        [Inject] private HudManager _hudManager;
        [Inject] private Bank _bank;
        protected override void Show()
        {
            _view.ToggleSound.OnSwitch += OnSwitchSound;
            _view.ToggleMusic.OnSwitch += OnSwitchMusic;
            _view.ToggleSound.Change(_audioManager.IsAudioActive(AudioType.Sound));
            _view.ToggleMusic.Change(_audioManager.IsAudioActive(AudioType.Music));
            _view.CoinsView.Initialize(_bank);
            _view.PlayButton.AddListener(Play);
        }

        protected override void Hide()
        {
            _view.ToggleSound.OnSwitch -= OnSwitchSound;
            _view.ToggleMusic.OnSwitch -= OnSwitchMusic;
            _view.PlayButton.RemoveListener(Play);
            _view.CoinsView.Dispose();
        }
        
        private void OnSwitchSound()
        {
            _audioManager.SwitchAudio(AudioType.Sound);
        }
        
        private void OnSwitchMusic()
        {
            _audioManager.SwitchAudio(AudioType.Music);
        }

        private void Play()
        {
            _gameController.Play();
            _hudManager.HideAdditional<StartHudMediator>();
            
        }
    }
}