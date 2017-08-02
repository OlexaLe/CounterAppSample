using System;
using System.ComponentModel;

namespace CounterApp
{
    internal class CounterReducer
    {
        public CounterState Reduce(CounterState state, object action)
        {
            switch (action)
            {
                case IncrementAction i:
                    return ProcessIncrement(state);

                case DecrementAction d:
                    return ProcessDecrement(state);

                default:
                    throw new ArgumentException("action is not supported");
            }
        }

        private CounterState ProcessDecrement(CounterState state)
        {
            return new CounterState(state.Count - 1);
        }

        private CounterState ProcessIncrement(CounterState state)
        {
            return new CounterState(state.Count + 1);
        }
    }

    internal class CounterState
    {
        public CounterState(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }

    internal class CounterStore : INotifyPropertyChanged
    {
        private readonly CounterReducer reducer = new CounterReducer();
        private CounterState state;

        public CounterStore(CounterState initialState)
        {
            state = initialState;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CounterState State
        {
            get { return state; }
            private set { state = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State))); }
        }

        public void Dispatch(object action)
        {
            State = reducer.Reduce(State, action);
        }
    }

    internal class DecrementAction
    { }

    internal class IncrementAction
    { }
}