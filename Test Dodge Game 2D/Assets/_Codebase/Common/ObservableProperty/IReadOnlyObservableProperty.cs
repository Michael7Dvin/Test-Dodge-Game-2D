using System;

namespace _Codebase.Common.ObservableProperty
{
    public interface IReadOnlyObservableProperty<out T>
    {
        event Action<T> Changed;
        T Value { get; }    
    }
}