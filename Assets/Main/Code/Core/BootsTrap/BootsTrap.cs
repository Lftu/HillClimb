using Main.Code.Audio;
using Main.Code.Configs;
using Main.Code.Core.Additional;
using UnityEngine;
using Zenject;

namespace Main.Code.Core
{
    public class BootsTrap : MonoInstaller
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private GameConfig _gameConfig;
      
        public override void InstallBindings()
        {
            Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
            Container.Bind<Bank>().FromInstance(new Bank()).AsSingle();
            Container.Bind<AudioManager>().FromInstance(new AudioManager()).AsSingle();
            Container.Bind<Timer>().FromInstance(_timer).AsSingle();
        }
    }
}