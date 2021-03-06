﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example6
{
    public class PlayerV6 : MonoBehaviour
    {
        [SerializeField] private HealthState _healthState = HealthState.Default;
        [SerializeField] private MovementState _movementState = MovementState.Default;

        public HealthEvent OnHealthUpdated;

        void Start()
        {
            OnHealthUpdated.Invoke(_healthState);
            _movementState.Position = transform.position;
        }

        void Update()
        {
            //Movement
            MovementInput input = GetInput();
            _movementState = Movement.Move(_movementState, input, Time.deltaTime);
            transform.position = _movementState.Position;
            
            //Health
            float oldHealth = _healthState.Health;
            _healthState = Health.Regeneration(_healthState, Time.deltaTime);
            
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

    }
}