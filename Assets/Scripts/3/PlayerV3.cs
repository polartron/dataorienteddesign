using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example3
{
    public class PlayerV3 : MonoBehaviour
    {
        [SerializeField] private HealthState _healthState = HealthState.Default;
        [SerializeField] private MovementState _movementState = MovementState.Default;

        public HealthEvent OnHealthUpdated;

        void Start()
        {
            OnHealthUpdated.Invoke(_healthState);
        }

        void Update()
        {
            Move();
            HealthUpdate();
        }

        void Move()
        {
            Vector2 move = Vector2.zero;
        
            if (Input.GetKey(KeyCode.W))
            {
                move.y += 1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                move.y -= 1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                move.x -= 1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                move.x += 1f;
            }
            
            float moveSpeed = _movementState.MoveSpeed;

            _movementState.Velocity *= Mathf.Clamp01(_movementState.SlowDown);
            _movementState.Velocity.x += Mathf.Clamp(move.x * Time.deltaTime, -moveSpeed, moveSpeed);
            _movementState.Velocity.z += Mathf.Clamp(move.y * Time.deltaTime, -moveSpeed, moveSpeed);
            transform.position = transform.position + _movementState.Velocity;
        }

        void HealthUpdate()
        {
            if (_healthState.Health <= 0)
                return;

            float oldHealth = _healthState.Health;

            if (_healthState.Regeneration > 0)
            {
                _healthState.Health += _healthState.Regeneration * Time.deltaTime;
                _healthState.Health = Mathf.Clamp(_healthState.Health, 0, _healthState.MaxHealth);
            }

            if (oldHealth != _healthState.Health)
            {
                OnHealthUpdated.Invoke(_healthState);
            }
        }
    }
}