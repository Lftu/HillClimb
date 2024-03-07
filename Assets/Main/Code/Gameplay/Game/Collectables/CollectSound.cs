using System.Collections;
using Main.Code.Audio;
using UnityEngine;
using Zenject;
using AudioType = Main.Code.Audio.AudioType;

namespace Main.Code.Gameplay.Game.Collactables
{
    public class CollectSound : MonoBehaviour
    {
        [Inject] private AudioManager _audioManager;
        [SerializeField] private AudioSource _audioSource;
        private AudioInstance _audioInstance;
        private void Awake()
        {
            _audioInstance = new AudioInstance(_audioSource, AudioType.Sound);
            _audioManager.AssignAudioInstance(_audioInstance);
            _audioInstance.Play();
            StartCoroutine(DestroyObj());
        }

        private IEnumerator DestroyObj()
        {
            yield return new WaitForSeconds(3f);
            _audioManager.RemoveAudioInstance(_audioInstance);
            Destroy(gameObject);
        }
    }
}