﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.UI;
using Main.Code.Gameplay.Game;
using Zenject;

namespace Main.Code.Core.UI
{
    public sealed class HudManager
    {
        [Inject] private GameView _gameView;
        [Inject] private DiContainer _injector;
       
        private Mediator _openedHud;
        private readonly List<Mediator> _additionalHuds;

        public HudManager()
        {
            _additionalHuds = new List<Mediator>();
        }

        public T ShowSingle<T>(object[] args = null) where T : Mediator
        {
            if (null != _openedHud)
            {
                HideSingle();
            }

            _openedHud = (Mediator)Activator.CreateInstance(typeof(T), args);
            _injector.Inject(_openedHud);
            var hudType = _openedHud.ViewType;
            var hudView = _gameView.AllHuds().FirstOrDefault(temp => temp.GetType() == hudType);
            _openedHud.Mediate(hudView);
            _openedHud.InternalShow();

            return (T)_openedHud;
        }
        
        public void HideSingle()
        {
            if (null == _openedHud)
                return;

            _openedHud.InternalHide();
            _openedHud.Unmediate();
            _openedHud = null;
        }

        public T ShowAdditional<T>(object[] args = null) where T : Mediator
        {
            var hud = (Mediator)Activator.CreateInstance(typeof(T), args);
            _injector.Inject(hud);
            var hudType = hud.ViewType;
            var hudView = _gameView.AllHuds().FirstOrDefault(temp => temp.GetType() == hudType);
            hud.Mediate(hudView);
            hud.InternalShow();

            _additionalHuds.Add(hud);
            return (T)hud;
        }

        public void HideAdditional<T>()
        {
            for (int i = _additionalHuds.Count - 1; i >= 0; i--)
            {
                var hud = _additionalHuds[i];

                if (!(hud is T))
                    continue;

                hud.InternalHide();
                hud.Unmediate();
                _additionalHuds.RemoveAt(i);
            }
        }
    }
}