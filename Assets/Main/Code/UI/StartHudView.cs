using Main.Code.Core.UI;
using Main.Code.UI.Additional;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Code.UI
{
    public sealed class StartHudView : BaseHud
    {
        [SerializeField] private ToggleView _toggleSound;
        [SerializeField] private ToggleView _toggleMusic;
        [SerializeField] private Button _playButton;
        [SerializeField] private CoinsView _coinsView;
        public ToggleView ToggleSound => _toggleSound;
        public ToggleView ToggleMusic => _toggleMusic;
        public Button PlayButton => _playButton;
        public CoinsView CoinsView => _coinsView;
        protected override void OnEnable()
        {
        }

        protected override void OnDisable()
        {
        }
        
    }
}