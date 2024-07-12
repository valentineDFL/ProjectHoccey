using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    internal class OptionsAudioToolBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private UnityEngine.UI.Image _imageToChange;
        private float _minLeft = 0;
        private float _maxRight = 0;

        private bool _isClicked = false;
        private float _preRes = 0;
        private float _maxPercent = 0;
        private float _thisSize = 0;
        private Vector3 _currentPos = Vector3.zero;
        private AudioSource _audio;
        [SerializeField] private UnityEngine.UI.Image _greenLine;


        private void Start()
        {           
            _imageToChange = GetComponent<UnityEngine.UI.Image>();
            _audio = GetComponent<AudioSource>();

            float with = this.transform.parent.GetComponent<RectTransform>().rect.width;
            _minLeft = (-with / 2) + (this.transform.GetComponent<RectTransform>().rect.width / 2);
            _maxRight = MathF.Abs(_minLeft);
            _maxPercent = this.transform.parent.GetComponent<RectTransform>().rect.width - this.transform.GetComponent<RectTransform>().rect.width;
            _thisSize = this.transform.GetComponent<RectTransform>().rect.width;

            transform.localPosition = new Vector2(PlayerPrefs.GetFloat(KeyScore.PositionSave), 0);
            _greenLine.fillAmount = PlayerPrefs.GetFloat(KeyScore.AudioSave);
        }

        private void Update()
        {
            _currentPos = transform.localPosition;
            Vector2 Mouse = Input.mousePosition;
            Mouse.x -= Screen.width / 2;
            
            if (_isClicked)
            {                  
                transform.localPosition = new Vector3(Mathf.Clamp(Mouse.x - transform.parent.localPosition.x, _minLeft, _maxRight), 0, 0);
                EventForChangeColor.ChangeColor();
                SetCounter();
                _audio.volume = _greenLine.fillAmount;
            }
        }

        private void OnEnable()
        {
            _preRes = PlayerPrefs.GetFloat(KeyScore.Percent);
            EventForChangeColor.ChangeColEv += ColorChangeActivate;
        }

        private void OnDisable()
        {
            EventForChangeColor.ChangeColEv -= ColorChangeActivate;    
        }

        public void ColorChangeActivate()
        {
            float startPosForFill = (this.transform.localPosition.x - this.GetComponent<RectTransform>().rect.width / 2);
            _greenLine.fillAmount = (startPosForFill + this.transform.parent.GetComponent<RectTransform>().rect.width / 2) / (this.transform.parent.GetComponent<RectTransform>().rect.width - _thisSize);
            _preRes = _greenLine.fillAmount * 100;
        }

        public void SetCounter()
        {
            PlayerPrefs.SetInt(KeyScore.Percent, (int)_preRes);
        }
        
        public void SavePosition()
        {
            PlayerPrefs.SetFloat(KeyScore.PositionSave, transform.localPosition.x);
            PlayerPrefs.SetFloat(KeyScore.AudioSave, _greenLine.fillAmount);
        }

        public void OnPointerDown(PointerEventData ev)
        {
            _imageToChange.color = Color.green;
            _isClicked = true;

            _audio.Play();
        }
        public void OnPointerUp(PointerEventData ev)
        {
            transform.localPosition = _currentPos;
            _imageToChange.color = Color.red;

            _isClicked = false;
            SavePosition();

            _audio.Pause();          
        }
        

    }
}
