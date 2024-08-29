using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";

        public float MoveDirection { get; private set; }

        public void Tick()
        {
            MoveDirection = Input.GetAxis(HorizontalAxisName);
        }
    }
}