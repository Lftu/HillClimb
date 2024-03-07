using System.Collections.Generic;
using Main.Code.Core.UI;
using UnityEngine;

namespace Main.Code.Gameplay.Game
{
    public sealed class GameView : MonoBehaviour
    {
        [SerializeField] private AudioSource _gameBackgroundMusic;
        [SerializeField] private AudioSource _startBackgroundMusic;
        [SerializeField] private GameObject _player;
        [SerializeField] private BaseHud[] _huds;
        [SerializeField] private Transform _carSpawnPosition;
        public AudioSource GameBackgroundMusic => _gameBackgroundMusic;
        public AudioSource StartBackgroundMusic => _startBackgroundMusic;
        public GameObject Player => _player;
        public Transform CarSpawnPosition => _carSpawnPosition;
        public IEnumerable<IHud> AllHuds()
        {
            foreach (var hud in _huds)
            {
                yield return hud;
            }
        }
    }
}