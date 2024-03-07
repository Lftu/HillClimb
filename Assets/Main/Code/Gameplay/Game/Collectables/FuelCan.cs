using System;
using UnityEngine;
using Zenject;

namespace Main.Code.Gameplay.Game.Collactables
{
    public class FuelCan : MonoBehaviour, ICollectable
    {
        [SerializeField] private GameObject _collectSound;
        [Inject] private DiContainer _diContainer;
        [Inject] private GameController _gameController;
        public void Collect()
        {
            _diContainer.InstantiatePrefab(_collectSound, transform.position, Quaternion.identity, transform.parent);
            _gameController.Car.RefillFuel();
            Destroy(gameObject);
        }
    }
}