using System;
using Unity.Entities;
using UnityEngine;

namespace Example9
{
    public static class Movement
    {
        public static void Move(ref MovementState state, in MovementConfig config, in MovementInput input, float deltaTime)
        {
            Vector2 moveVector = input.MoveVector * config.MoveSpeed;

            //Slow down
            state.Velocity.x *= config.SlowDown;
            state.Velocity.z *= config.SlowDown;

            //Jump
            if (input.Jump)
            {
                Jump(ref state, config.JumpPower);
            }

            //Gravity
            ApplyGravity(ref state.Velocity, config.Gravity, deltaTime);
            Accelerate(ref state.Velocity, moveVector, config.MoveSpeed, deltaTime);
            
            //Move
            state.Position += state.Velocity;
            CheckGround(ref state);
        }

        public static void ApplyGravity(ref Vector3 velocity, float gravity, float deltaTime)
        {
            velocity.y -= gravity * deltaTime;
        }
        
        public static void CheckGround(ref MovementState state)
        {
            if (state.Position.y < 0f)
            {
                state.IsGrounded = true;
                state.Position.y = 0f;
            }
        }

        public static void Jump(ref MovementState state, float jumpPower)
        {
            if (!state.IsGrounded)
                return;
            
            state.IsGrounded = false;
            state.Velocity.y = jumpPower;
        }

        private static void Accelerate(ref Vector3 velocity, in Vector3 moveVector, float acceleration, float deltaTime)
        {
            velocity.x += Mathf.Clamp(moveVector.x * Time.deltaTime, -acceleration, acceleration);
            velocity.z += Mathf.Clamp(moveVector.y * Time.deltaTime, -acceleration, acceleration);
        }
    }
}