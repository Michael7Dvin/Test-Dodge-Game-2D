using _Codebase.Common.ObservableProperty;
using UnityEngine;

namespace _Codebase.Gameplay.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Transform _transform;

        private float _moveSpeed;
        private ObservableProperty<bool> _isMoving = new();

        public void Construct(float moveSpeed)
        {
            _moveSpeed = moveSpeed;

            _rigidbody = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        public IReadOnlyObservableProperty<bool> IsMoving => _isMoving;

        private bool IsFacingRight => 
            _transform.localScale.x > 0;

        public bool Enabled { get; set; } = true;

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
            if (characterPosition.x < newPosition.x && IsFacingRight == true)
                Flip();
            else if (characterPosition.x > newPosition.x && IsFacingRight == false)
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