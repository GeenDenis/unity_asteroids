using UnityEngine;

namespace Asteroids.Scripts.Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float destroyDistance;
        
        private Vector3 _moveVector;
        private float _movedDistance;
        
        public void AddMoveVector(Vector3 vector)
        {
            _moveVector = Vector3.ClampMagnitude(_moveVector + vector, 17f);
        }
        
        private void FixedUpdate()
        {
            var vector = _moveVector * Time.fixedDeltaTime;
            _movedDistance += vector.magnitude;
            transform.Translate(vector, Space.World);

            if (_movedDistance > destroyDistance)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDestroyable>(out var obj))
            {
                obj.Destroy();
                Destroy(gameObject);
            }
        }
    }
}