using Main.Code.Gameplay.Game.Collactables;
using UnityEngine;
using Zenject;

namespace Main.Code.Gameplay.Game.Car
{
    public class Head : MonoBehaviour
    {
        [Inject] private GameController _gameController;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Ground ground = other.gameObject.GetComponent<Ground>();
            if (ground != null)
            {
                _gameController.Lose();
            }
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