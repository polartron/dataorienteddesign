using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Example9
{
    public class CharacterMoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;
            
            Entities.ForEach((ref Translation translation, ref MovementState state, in MovementConfig config, in MovementInput input) =>
            {
                Movement.Move(ref state, config, input, deltaTime);
                translation.Value = state.Position;
            }).Run();
        }
    }

}
