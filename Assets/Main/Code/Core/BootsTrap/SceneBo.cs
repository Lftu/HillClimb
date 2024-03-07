using Main.Code.Core.UI;
using Main.Code.Gameplay.Game;
using UnityEngine;
using Zenject;

namespace Main.Code.Core
{
    public class SceneBo : MonoInstaller
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private CameraControl _cameraControl;
        public override void InstallBindings()
        {
            GameController gameController = new GameController();
            HudManager hudManager = new HudManager();

            Container.Bind<CameraControl>().FromInstance(_cameraControl).AsSingle();
            Container.Bind<GameView>().FromInstance(_gameView);
            Container.Bind<GameController>().FromInstance(gameController).AsSingle();
            Container.Bind<HudManager>().FromInstance(hudManager).AsSingle();
            Container.Inject(hudManager);
            Container.Inject(gameController);
        }
    }
}