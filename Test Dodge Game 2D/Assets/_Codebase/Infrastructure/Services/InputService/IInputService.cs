using UniRx;

namespace _Codebase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        IReadOnlyReactiveProperty<float> HorizontalMoveInput { get; }
    }
}