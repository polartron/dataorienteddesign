using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example4
{
    public class PlayerV4 : MonoBehaviour
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
            MovementInput input = GetInput();
            Move(input);
            Regeneration();
        }

        MovementInput GetInput()
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

            return new MovementInput()
            {
                MoveVector = move
            };
        }
        
        void Move(MovementInput input)
        {
            Vector2 moveVector = input.MoveVector;
            float moveSpeed = _movementState.MoveSpeed;

            _movementState.Velocity *= Mathf.Clamp01(_movementState.SlowDown);
            _movementState.Velocity.x += Mathf.Clamp(moveVector.x * Time.deltaTime, -moveSpeed, moveSpeed);
            _movementState.Velocity.z += Mathf.Clamp(moveVector.y * Time.deltaTime, -moveSpeed, moveSpeed);
            transform.position = transform.position + _movementState.Velocity;
        }

        void Regeneration()
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