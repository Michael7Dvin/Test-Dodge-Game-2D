using _Codebase.Gameplay.Heroes.Components;
using _Codebase.Infrastructure.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Codebase.Gameplay.Heroes
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(Health))]
    public class Hero : MonoBehaviour
    {
        private IInputService _inputService;
        
        [Inject]
        public void InjectServices(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Construct(Mover mover, HeroAnimator heroAnimator)
        {
            Mover = mover;
            HeroAnimator = heroAnimator;
        }

        public Transform Transform { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Animator Animator { get; private set; }
        
        public Mover Mover { get; private set; }
        public HeroAnimator HeroAnimator { get; private set; }
        
        public Health Health { get; private set; }
        
        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            
            Health = GetComponent<Health>();
        }

        public void Initialize()
        {
            _inputService.HorizontalMoveInput
                .Subscribe(horizontalMoveInput =>
                {
                    Vector2 moveDirection = new Vector2(horizontalMoveInput, 0);
                    Mover.Move(moveDirection);
                })
                .AddTo(this);
            
            Mover.IsMoving
                .Subscribe(isMoving => HeroAnimator.ChangeIsMovingState(isMoving))
                .AddTo(this);
            
            Mover.Enabled = true;
        }

    }
}