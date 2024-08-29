using _Codebase.Common.ObservableProperty;

namespace _Codebase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        IReadOnlyObservableProperty<float> HorizontalMoveInput { get; }
    }
}