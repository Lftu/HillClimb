using System;
using Main.Code.Core.Additional;
using Zenject;

namespace Main.Code.Core.State
{
    public abstract class State : IDisposable
    {
        [Inject] protected Timer _timer;
        public void Initialized()
        {
            _timer.OnTick += Update;
            OnStart();
        }

        protected abstract void OnStart();
        public void Dispose()
        {
            _timer.OnTick -= Update;
            OnDispose();
        }
        
        protected abstract void OnDispose();

        protected virtual void Update()
        {
            
        }

        
    }
}