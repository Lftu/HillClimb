using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Code.Audio {
    public sealed class AudioManager
    {
        private const int Types = 2;

        private bool[] _isAudioActive = new bool[Types];

        public Action<bool>[] OnAudioChange = new Action<bool>[Types];
        private List<AudioInstance> _assignedAudio = new ();

        public AudioManager()
        {
            for (int i = 0; i < Types; i++)
            {
                int audioType = PlayerPrefs.GetInt("Audio " + (AudioType)i, 1);
                _isAudioActive[i] = ConvertIntToBool(audioType);
            }
        }

        public void SwitchAudio(AudioType audioType)
        {
            int audioTypeIndex = (int)audioType;
            _isAudioActive[audioTypeIndex] = !_isAudioActive[audioTypeIndex];
            PlayerPrefs.SetInt("Audio " + audioType, ConvertBoolToInt(_isAudioActive[audioTypeIndex]));
            OnAudioChange[audioTypeIndex]?.Invoke(_isAudioActive[audioTypeIndex]);
        }

        public bool IsAudioActive(AudioType audioType)
        {
            return _isAudioActive[(int)audioType];
        }
        
        private bool ConvertIntToBool(int num)
        {
            return num == 1;
        }

        private int ConvertBoolToInt(bool state)    
        {
            return state ? 1 : 0;
        }

        public void AssignAudioInstance(AudioInstance audioInstance)
        {
            audioInstance.Initialize(this);
            _assignedAudio.Add(audioInstance);
        }

        public void RemoveAudioInstance(AudioInstance audioInstance)
        {
            if (_assignedAudio.Contains(audioInstance))
            {
                _assignedAudio.Remove(audioInstance);
            }
        }
    }
}

