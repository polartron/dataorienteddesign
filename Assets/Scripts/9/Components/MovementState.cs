using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Example9
{
    [GenerateAuthoringComponent]
    public struct MovementState : IComponentData
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public bool IsGrounded;
    }

}
