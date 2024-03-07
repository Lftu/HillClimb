using System;
using UnityEngine;

namespace Main.Code.Core.Additional
{
    public sealed class Timer : MonoBehaviour
    {
        public Action OnTick;
        public Action PostTick;
        public Action FixedTick;
        public Action OneSecondTick;
    

        private float _unscaledTime;
        private float _lastTime;
        private float _deltaTime;
        private float _scaleTime;
        private float _time;

        public Timer()
        {
            _lastTime = GetTime();
            _scaleTime = 1f;
            _deltaTime = 0f;
            _time = 0f;
        }

        public float Time => _time;
        public float DeltaTime => _deltaTime;
        public float TimeScale { get => _scaleTime;
            set => _scaleTime = Math.Max(0f, value);
        }
        public float UnscaladeTime => _unscaledTime;

        public void Update()
        {
            var now = GetTime();
            var delta = now - _lastTime;
            _unscaledTime += delta;
            _deltaTime = delta * TimeScale;
            _time += _deltaTime;

            bool isNewSecondTick = Mathf.Floor(now) > Mathf.Floor(_lastTime);

            _lastTime = now;

            OnTick?.Invoke();

            if (isNewSecondTick)
            {
                OneSecondTick?.Invoke();
            }
        }

        public void LateUpdate()
        {
            PostTick?.Invoke();
        }

        public void FixedUpdate()
        {
            FixedTick?.Invoke();
        }

        private float GetTime()
        {
            return Environment.TickCount / 1000f;
        }
        
        public static float CalculateTimeDifferenceInSeconds(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan timeDifference = dateTime2 - dateTime1;
            double secondsDifference = timeDifference.TotalSeconds;
            return (float)secondsDifference;
        }
    }
}