using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.UI.scrollbar.AudioSave
{
    internal class MainMenuBackgroundMusicSave : MonoBehaviour
    {
        private float _audioPercent;
        private AudioSource _audioSource;
        

        private void Start()
        {
            _audioPercent = PlayerPrefs.GetFloat(KeyScore.AudioSave);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = _audioPercent;
        }

    }
}
