using _Codebase.Gameplay.Hero.Components;
using _Codebase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Codebase.Gameplay.Hero
{
    [RequireComponent(typeof(Mover))]
    public class Hero : MonoBehaviour
    {
        private IInputService _inputService;
        
        [Inject]
        public void InjectServices(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public Mover Mover { get; private set; }

        private void Awake()
        {
            Mover = GetComponent<Mover>();
        }

        public void Initialize()
        {
            _inputService.HorizontalMoveInput.Changed += OnHorizontalInput;

            Mover.Enabled = true;
        }

        private void OnHorizontalInput(float horizontalMoveInput)
        {
            Vector2 moveDirection = new Vector2(horizontalMoveInput, 0);
            Mover.Move(moveDirection);
        }

        private void OnDestroy()
        {
            _inputService.HorizontalMoveInput.Changed -= OnHorizontalInput;
        }
    }
}