using System;
using UnityEngine;

namespace Assets.Scripts.MenuEscape
{
    internal class OpenMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _offButton;

        private void Start()
        {
            Time.timeScale = 1.0f;
        }

        public void Resume()
        {
            Time.timeScale = 1;
            _panel.SetActive(false);
            _offButton.SetActive(true);
            
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
            _offButton.SetActive(false);
        }


    }
}
