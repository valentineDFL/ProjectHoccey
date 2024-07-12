using System;
using UnityEngine;

namespace Assets.Scripts.Score_Num.Gates
{
    public class BotGate : Gates
    {
        private int _round = 0;
        private int _scoreTop = 0;

        private void Start()
        {
            _scoreTop = PlayerPrefs.GetInt(KeyScore.ScoreTop);
            _gate = this.gameObject;
            _side = Side.Top;
        }
        private void OnEnable()
        {
            _round = PlayerPrefs.GetInt(KeyScore.Round);
            _scoreTop = PlayerPrefs.GetInt(KeyScore.ScoreTop);

            TopPlus += ScoreChangeEvent;
        }
        private void OnDisable()
        {
            TopPlus -= ScoreChangeEvent;
        }

        public override void ScoreChangeEvent()
        {       
            _round += 1;
            _scoreTop += 1;

            PlayerPrefs.SetInt(KeyScore.Round, _round);
            PlayerPrefs.SetInt(KeyScore.ScoreTop, _scoreTop);
            SceneRestart.RestartScene();     
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
           if (collision.gameObject.GetComponent<PuckMoveAbility>())
           {
               EventActivate(_side);
           }
        }
    }
}
