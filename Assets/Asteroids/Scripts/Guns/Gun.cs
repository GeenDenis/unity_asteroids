using Unity.Mathematics;
using UnityEngine;

namespace Asteroids.Scripts.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletSpeed;

        public Bullet Fire()
        {
            var bullet = Instantiate(_bulletPrefab, transform.position, quaternion.identity);
            bullet.AddMoveVector(transform.up * _bulletSpeed);
            return bullet;
        }
    }
}