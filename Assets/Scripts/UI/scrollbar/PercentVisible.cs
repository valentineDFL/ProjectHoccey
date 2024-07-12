using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal class PercentVisible : MonoBehaviour
    {
        private Text _text;
        private float _percent = 0;

        private void Start()
        {
            _text = GetComponent<Text>();
        }
        private void Update()
        {
            _percent = PlayerPrefs.GetInt(KeyScore.Percent);
            _text.text = $"percent {_percent}/100";
        }
    }
}
