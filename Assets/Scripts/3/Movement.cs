using System;
using UnityEngine;

namespace Example3
{
    [Serializable]
    public struct MovementState
    {
        public Vector3 Velocity;
        public float MoveSpeed;
        public float SlowDown;

        public static MovementState Default = new MovementState()
        {
            MoveSpeed = 1f,
            SlowDown = 0.9f,
        };
    }
}
