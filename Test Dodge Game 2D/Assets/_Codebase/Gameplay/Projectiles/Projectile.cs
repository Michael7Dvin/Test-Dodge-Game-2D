using System;
using _Codebase.Gameplay.Heroes.Components;
using UnityEngine;

namespace _Codebase.Gameplay.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _moveSpeed;

        public void Construct(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        public Action<Projectile> Hit { get; set; }

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void FixedUpdate() => 
            Move();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health)) 
                health.Damage();
            
            Hit?.Invoke(this);
        }

        private void Move()
        {
            Vector2 characterPosition = _rigidbody.position;
            Vector2 newPosition = characterPosition + Vector2.down * (_moveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }
    }
}