using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Example9
{
    [GenerateAuthoringComponent]
    public struct MovementInput : IComponentData
    {
        public Vector2 MoveVector;
        public bool Jump;
    }
}

