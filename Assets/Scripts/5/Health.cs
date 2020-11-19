using System;
using UnityEngine.Events;

namespace Example5
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
}