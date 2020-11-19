using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Example9
{
    public class AiInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref MovementInput input, in AiTag aiTag) =>
            {
                Vector2 move = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                bool jump = Random.Range(0, 20) == 0;
                
                input = new MovementInput()
                {
                    MoveVector = move,
                    Jump = jump
                };
            }).Run();
        }
    }
}