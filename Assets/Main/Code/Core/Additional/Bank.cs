using System;
using UnityEngine;

namespace Main.Code.Core.Additional
{
    public class Bank
    {
        public int Coins { get; private set; }
        private const string Key = "Coins";
        public Action OnCoinsChange;

        public Bank()
        {
            Coins = PlayerPrefs.GetInt(Key, 0);
        }
        
        public void ChangeCoinsNumber(int change)
        {
            Coins += change;
            PlayerPrefs.SetInt(Key, Coins);
            OnCoinsChange?.Invoke();
        }
    }
}