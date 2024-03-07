using System;
using Main.Code.Gameplay.Game.Collactables;
using UnityEngine;
using Zenject;

namespace Main.Code.Gameplay.Game.Car
{
    public class Car : MonoBehaviour
    {
        [Inject] private GameController _gameController;
        [SerializeField] private Rigidbody2D _frontWheelRigidbody;
        [SerializeField] private Rigidbody2D _backWheelRigidbody;
        [SerializeField] private Rigidbody2D _carRigidbody;
        [SerializeField] private AudioSource _gas;
        private float _speed = 100f;
        private float _rotationSpeed = 700f;
        private float _moveValue;
        private float _fuelMeter = 100;
        private float _fuelSpendSpeed = 15;
        private bool _isHeadDead;
        public Action<float> OnFuelChange;

        public void GasDown()
        {
            _moveValue += 1;
            _gas.Play();
        }
        
        public void GasUp()
        {
            _moveValue -= 1;
            _gas.Stop();
        }

        public void BrakeDown()
        {
            _moveValue -= 1;
        }
        public void BrakeUp()
        {
            _moveValue += 1;
        }
        private void FixedUpdate()
        {
            if(_isHeadDead) return;
            if (_fuelMeter > 0)
            {
                _frontWheelRigidbody.AddTorque(-_moveValue * _speed * Time.fixedDeltaTime);
                _backWheelRigidbody.AddTorque(-_moveValue * _speed * Time.fixedDeltaTime);
                _carRigidbody.AddTorque(-_moveValue * _rotationSpeed * Time.fixedDeltaTime);
            }
            else if (_carRigidbody.velocity.magnitude < 0.001f)
            {
                _gameController.Lose();
                _isHeadDead = true;
            }
            
            if (_moveValue != 0)
            {
                _fuelMeter = Math.Clamp(_fuelMeter - _fuelSpendSpeed * Time.fixedDeltaTime, 0, 100);
                OnFuelChange?.Invoke(_fuelMeter);
            }
        }

        public void RefillFuel()
        {
            _fuelMeter = 100;
            OnFuelChange?.Invoke(_fuelMeter);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            if (collectable != null)
            {
                collectable.Collect();
            }
        }
    }
}