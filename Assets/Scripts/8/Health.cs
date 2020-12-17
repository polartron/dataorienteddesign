using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example8
{
    [Serializable]
    public class HealthEvent : UnityEvent<HealthState>
    {
    }
    
    [Serializable]
    public struct HealthState
    {
        public float Health;
        public float MaxHealth;
        public float Regeneration;

        public static HealthState Default = new HealthState()
        {
            Health = 100f,
            Regeneration = 1f,
            MaxHealth = 100f
        };
    }

    public static class Health
    {
        public static void Regeneration(ref HealthState state, float deltaTime)
        {
            if (state.Health <= 0)
                return;

            if (state.Regeneration > 0)
            {
                state.Health += state.Regeneration * deltaTime;
                state.Health = Mathf.Clamp(state.Health, 0, state.MaxHealth);
            }
        }
    }
}