using Core.UI;
using Main.Code.Extentions;
using UnityEngine.SceneManagement;

namespace Main.Code.UI
{
    public sealed class GameOverHudMediator : Mediator<GameOverHudView>
    {
        protected override void Show()
        {
            _view.RestartButton.AddListener(RestartScene);
            _view.HomeButton.AddListener(RestartGame);
        }

        protected override void Hide()
        {
            _view.RestartButton.RemoveListener(RestartScene);
            _view.HomeButton.RemoveListener(RestartGame);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(0);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}