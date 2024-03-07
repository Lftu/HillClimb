using System;
using System.Collections.Generic;
using Zenject;

namespace Main.Code.Core.State
{
    public class StateController
    {
        [Inject] private DiContainer _diContainer;
        private Dictionary<Type, State> _statesMap = new Dictionary<Type, State>();
        private State _currentState;

        public void AddState(State state)
        {
            _diContainer.Inject(state);
            _statesMap.Add(state.GetType(), state);
        }

        public void ChangeState<T>() where T : State
        {
            if (!_statesMap.ContainsKey(typeof(T)))
            {
                return;
            }
            
            _currentState?.Dispose();

            _currentState = _statesMap[typeof(T)];
            
            _currentState.Initialized();
        }
    }
}