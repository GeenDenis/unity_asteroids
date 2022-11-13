using System;
using Asteroids.Scripts.Guns;
using Asteroids.Scripts.Ship.Movement;
using UnityEngine;

namespace Asteroids.Scripts.Ship
{
    public class SpaceShip : MonoBehaviour, IDestroyable
    {
        [SerializeField] private ShipMovement _movement;
        [SerializeField] private Gun _gun;

        public event Action OnDestroy = delegate { };

        private void Awake()
        {
            _movement.Init(transform);
        }

        private void Update()
        {
            _movement.SetActiveForwardThrust(Input.GetKey(KeyCode.UpArrow));
            var activeRotate = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
            var rotateDirection = Input.GetKey(KeyCode.LeftArrow)
                ? RotateDirection.Left
                : RotateDirection.Right;
            _movement.SetActiveRotate(activeRotate, rotateDirection);

            if (Input.GetKeyDown(KeyCode.Space)) Fire();
        }

        public void Fire()
        {
            _gun.Fire().AddMoveVector(_movement.MoveVector);
        }
        
        public void Destroy()
        {
            OnDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}