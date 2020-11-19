using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Example9
{
    public class PlayerInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref MovementInput input, in PlayerTag playerTag) =>
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

                input = new MovementInput()
                {
                    MoveVector = move,
                    Jump = Input.GetKeyDown(KeyCode.Space)
                };
            }).Run();
        }
    }
}
