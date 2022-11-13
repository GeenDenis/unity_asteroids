using System;
using UnityEngine;

namespace Asteroids.Scripts.Asteroids
{
    public class Asteroid : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroy = delegate { };

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDestroyable>(out var obj))
            {
                obj.Destroy();
                Destroy();
            }
        }

        public void Destroy()
        {
            OnDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}