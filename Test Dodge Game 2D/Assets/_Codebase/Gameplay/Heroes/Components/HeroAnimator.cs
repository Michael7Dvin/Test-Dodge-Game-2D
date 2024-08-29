using UnityEngine;

namespace _Codebase.Gameplay.Heroes.Components
{
    public class HeroAnimator
    {
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");

        private readonly Animator _animator;

        public HeroAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void ChangeIsMovingState(bool isMoving)
        {
            _animator.SetBool(_isMovingHash, isMoving);
        }
    }
}