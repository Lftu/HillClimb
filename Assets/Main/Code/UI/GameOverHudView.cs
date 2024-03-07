using Main.Code.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Code.UI
{
    public sealed class GameOverHudView : BaseHud
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;
        public Button RestartButton => _restartButton;
        public Button HomeButton => _homeButton;
        protected override void OnEnable()
        {
            
        }

        protected override void OnDisable()
        {
            
        }
    }
}