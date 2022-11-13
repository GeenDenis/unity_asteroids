using UnityEngine;

namespace Asteroids.Scripts.Ship.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _thrustPower;
        [SerializeField, Range(0, 1)] private float _brakingPower;

        private Transform _root;
        private bool _activeForwardThrust;
        private float _rotationAngle;

        public Vector3 MoveVector { get; private set; }

        public void Init(Transform root)
        {
            _root = root;
        }
        
        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            if(_activeForwardThrust) HandleForwardThrust(deltaTime);
            if(!_activeForwardThrust) HandleBraking();
            _root.Translate(MoveVector * deltaTime, Space.World);
            _root.Rotate(Vector3.forward, _rotationAngle * deltaTime);
        }

        private void HandleForwardThrust(float deltaTime)
        {
            MoveVector += _root.up * (_thrustPower * deltaTime);
            MoveVector = Vector3.ClampMagnitude(MoveVector, _maxSpeed);
        }
        
        private void HandleBraking()
        {
            MoveVector *= _brakingPower;
        }

        public void SetActiveForwardThrust(bool active)
        {
            _activeForwardThrust = active;
        }

        public void SetActiveRotate(bool active, RotateDirection direction)
        {
            _rotationAngle = active ? _rotationSpeed * (int)direction : 0f;
        }
    }
}