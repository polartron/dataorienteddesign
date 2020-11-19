using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example5
{
    public class PlayerV5 : MonoBehaviour
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
            //Movement
            MovementInput input = GetInput();
            _movementState = Move(_movementState, input);
            transform.position = transform.position + _movementState.Velocity;
            
            //Health
            float oldHealth = _healthState.Health;
            _healthState = Regeneration(_healthState);
            
            if (oldHealth != _healthState.Health)
            {
                OnHealthUpdated.Invoke(_healthState);
            }
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
        
        static MovementState Move(MovementState state, MovementInput input)
        {
            Vector2 moveVector = input.MoveVector;
            float moveSpeed = state.MoveSpeed;

            state.Velocity *= Mathf.Clamp01(state.SlowDown);
            state.Velocity.x += Mathf.Clamp(moveVector.x * Time.deltaTime, -moveSpeed, moveSpeed);
            state.Velocity.z += Mathf.Clamp(moveVector.y * Time.deltaTime, -moveSpeed, moveSpeed);

            return state;
        }

        static HealthState Regeneration(HealthState state)
        {
            if (state.Health <= 0)
                return state;

            if (state.Regeneration > 0)
            {
                state.Health += state.Regeneration * Time.deltaTime;
                state.Health = Mathf.Clamp(state.Health, 0, state.MaxHealth);
            }

            return state;
        }
    }
}