using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example3
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
