using Main.Code.Core.Additional;
using UnityEngine;
using Zenject;

namespace Main.Code.Gameplay.Game.Collactables
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private int _moneyGet;
        [SerializeField] private GameObject _collectSound;
        [Inject] private DiContainer _diContainer;
        [Inject] private Bank _bank;
        public void Collect()
        {
            _diContainer.InstantiatePrefab(_collectSound, transform.position, Quaternion.identity, transform.parent);
            _bank.ChangeCoinsNumber(_moneyGet);
            Destroy(gameObject);
        }
    }
}