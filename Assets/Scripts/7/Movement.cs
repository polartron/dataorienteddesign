using System;
using UnityEngine;

namespace Example7
{
    public struct MovementInput
    {
        public Vector2 MoveVector;
        public bool Jump;
    }
    
    public struct MovementState
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public bool IsGrounded;
    }

    [Serializable]
    public struct MovementConfig
    {
        public float MoveSpeed;
        public float SlowDown;
        public float JumpPower;
        public float Gravity;
        
        public static MovementConfig Default = new MovementConfig()
        {
            MoveSpeed = 1f,
            SlowDown = 0.9f,
            JumpPower = 0.2f,
            Gravity = 1f
        };
    }

    public static class Movement
    {
        public static MovementState Move(MovementState state, MovementConfig config, MovementInput input, float deltaTime)
        {
            Vector2 moveVector = input.MoveVector * config.MoveSpeed;

            //Slow down
            state.Velocity.x *= config.SlowDown;
            state.Velocity.z *= config.SlowDown;

            //Jump
            if (input.Jump)
            {
                state = Jump(state, config.JumpPower);
            }

            //Gravity
            state.Velocity = ApplyGravity(state.Velocity, config.Gravity, deltaTime);
            state.Velocity = Accelerate(state.Velocity, moveVector, config.MoveSpeed, deltaTime);
            
            //Move
            state.Position += state.Velocity;
            state = CheckGround(state);

            return state;
        }

        public static Vector3 ApplyGravity(Vector3 velocity, float gravity, float deltaTime)
        {
            velocity.y -= gravity * deltaTime;
            return velocity;
        }
        
        public static MovementState CheckGround(MovementState state)
        {
            if (state.Position.y < 0f)
            {
                state.IsGrounded = true;
                state.Position.y = 0f;
            }

            return state;
        }

        public static MovementState Jump(MovementState state, float jumpPower)
        {
            if (!state.IsGrounded)
                return state;
            
            state.IsGrounded = false;
            state.Velocity.y = jumpPower;
            return state;
        }

        private static Vector3 Accelerate(Vector3 velocity, in Vector3 moveVector, float acceleration, float deltaTime)
        {
            velocity.x += Mathf.Clamp(moveVector.x * Time.deltaTime, -acceleration, acceleration);
            velocity.z += Mathf.Clamp(moveVector.y * Time.deltaTime, -acceleration, acceleration);
            return velocity;
        }
    }
}