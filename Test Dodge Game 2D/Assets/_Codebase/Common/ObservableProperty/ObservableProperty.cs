using System;

namespace _Codebase.Common.ObservableProperty
{
    public class ObservableProperty<T> : IReadOnlyObservableProperty<T> where T : struct
    {
        private T _value;

        public ObservableProperty()
        {
        }

        public ObservableProperty(T value)
        {
            _value = value;
        }

        public event Action<T> Changed;

        public T Value
        {
            get => _value;

            set
            {
                if (_value.Equals(value))
                    return;

                _value = value;
                Changed?.Invoke(_value);
            }
        }
    }
}