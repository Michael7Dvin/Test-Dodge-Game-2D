using _Codebase.Common.ObservableProperty;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        private readonly ObservableProperty<float> _horizontalMoveInput = new();
        
        public IReadOnlyObservableProperty<float> HorizontalMoveInput => _horizontalMoveInput;

        public void Tick()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxisName);
            
            if (horizontalInput != 0)
                _horizontalMoveInput.SetValueAndForceNotify(horizontalInput);
            else
                _horizontalMoveInput.Value = horizontalInput;
        }
    }
}