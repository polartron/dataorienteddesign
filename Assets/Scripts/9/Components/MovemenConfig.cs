using System;
using Unity.Entities;

namespace Example9
{
    [Serializable]
    [GenerateAuthoringComponent]
    public struct MovementConfig : IComponentData
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
}