using System;
using Main.Code.Core.Additional;
using TMPro;
using UnityEngine;
using Zenject;

namespace Main.Code.UI.Additional {
    public class CoinsView : MonoBehaviour, IDisposable
    {
        private TMP_Text _coinsText;
        private Bank _bank;

        public void Initialize(Bank bank)
        {
            _bank ??= bank;
            _bank.OnCoinsChange += OnCoinsChange;
            OnCoinsChange();
        }
        public void Dispose()
        {
            _bank.OnCoinsChange -= OnCoinsChange;
        }
        private void OnCoinsChange()
        {
            _coinsText ??= GetComponentInChildren<TMP_Text>();
            _coinsText.text = _bank.Coins.ToString();
        }
    }
}
