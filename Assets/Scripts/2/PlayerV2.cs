using System;
using UnityEngine;
using UnityEngine.Events;

namespace Example2
{
    public class PlayerV2 : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _regeneration = 1f;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _slowDown = 0.9f;

        [Serializable] public class HealthEvent : UnityEvent<float, float> {}
    
        public HealthEvent OnHealthUpdated;

        private Vector3 _velocity;

        void Start()
        {
            OnHealthUpdated.Invoke(_health, _maxHealth);
        }

        void Update()
        {
            Move();
            HealthUpdate();
        }

        void Move()
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

            _velocity *= Mathf.Clamp01(_slowDown);
            _velocity.x += Mathf.Clamp(move.x * Time.deltaTime, -_moveSpeed, _moveSpeed);
            _velocity.z += Mathf.Clamp(move.y * Time.deltaTime, -_moveSpeed, _moveSpeed);
            transform.position = transform.position + _velocity;
        }

        void HealthUpdate()
        {
            if (_health <= 0)
                return;

            float oldHealth = _health;
        
            if (_regeneration > 0)
            {
                _health += _regeneration * Time.deltaTime;
                _health = Mathf.Clamp(_health, 0, _maxHealth);
            }

            if (oldHealth != _health)
            {
                OnHealthUpdated.Invoke(_health, _maxHealth);
            }
        }
    }
}