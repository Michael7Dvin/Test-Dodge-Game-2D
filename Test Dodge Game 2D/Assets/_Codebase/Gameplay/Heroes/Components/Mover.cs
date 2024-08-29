using _Codebase.Common.ObservableProperty;
using UnityEngine;

namespace _Codebase.Gameplay.Heroes.Components
{
    public class Mover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly float _moveSpeed;

        private readonly ObservableProperty<bool> _isMoving = new();

        public Mover(float moveSpeed, Transform transform, Rigidbody2D rigidbody2D)
        {
            _moveSpeed = moveSpeed;

            _rigidbody = rigidbody2D;
            _transform = transform;
        }

        public IReadOnlyObservableProperty<bool> IsMoving => _isMoving;

        private bool IsFacingRight => 
            _transform.localScale.x > 0;

        public bool Enabled { get; set; }

        public void Move(Vector2 direction)
        {
            if (Enabled == false || direction == Vector2.zero)
            {
                _isMoving.Value = false;
                return;
            }
            
            _isMoving.Value = true;

            
            Vector2 characterPosition = _rigidbody.position;
            Vector2 newPosition = characterPosition + direction * (_moveSpeed * Time.deltaTime);
            
            FlipTowardMoveDirection(characterPosition, newPosition);
            
            _rigidbody.MovePosition(newPosition);
        }

        private void FlipTowardMoveDirection(Vector2 characterPosition, Vector2 newPosition)
        {
            if (characterPosition.x < newPosition.x && IsFacingRight == false)
                Flip();
            else if (characterPosition.x > newPosition.x && IsFacingRight == true)
                Flip();
            
            void Flip()
            {
                Vector3 scale = _transform.localScale;
                scale.x *= -1;  
                _transform.localScale = scale;
            }
        }
    }
}