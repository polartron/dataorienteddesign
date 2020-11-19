using System;
using UnityEngine;

namespace Example6
{
    public struct MovementInput
    {
        public Vector2 MoveVector;
    }
    
    [Serializable]
    public struct MovementState
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public float MoveSpeed;
        public float SlowDown;

        public static MovementState Default = new MovementState()
        {
            MoveSpeed = 1f,
            SlowDown = 0.9f,
        };
    }

    public static class Movement
    {
        public static MovementState Move(MovementState state, MovementInput input, float deltaTime)
        {
            Vector2 moveVector = input.MoveVector * state.MoveSpeed;

            state.Velocity *= state.SlowDown;     
            state.Velocity = Accelerate(state.Velocity, moveVector, state.MoveSpeed, deltaTime);
            state.Position += state.Velocity;

            return state;
        }

        private static Vector3 Accelerate(Vector3 velocity, Vector3 moveVector, float acceleration, float deltaTime)
        {
            velocity.x += Mathf.Clamp(moveVector.x * Time.deltaTime, -acceleration, acceleration);
            velocity.z += Mathf.Clamp(moveVector.y * Time.deltaTime, -acceleration, acceleration);
            return velocity;
        }
    }
}