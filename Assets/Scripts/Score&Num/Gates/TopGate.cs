using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Score_Num.Gates
{
    public class TopGate : Gates
    {
        private int _round = 0;
        private int _scoreBott = 0;
        private int _sceneIndex;

        private void Start()
        {
            _scoreBott = PlayerPrefs.GetInt(KeyScore.ScoreBott);
            _gate = this.gameObject;
            _side = Side.Bottom;
            Time.timeScale = 1f;
        }

        private void OnEnable()
        {
            _round = PlayerPrefs.GetInt(KeyScore.Round);
            _scoreBott = PlayerPrefs.GetInt(KeyScore.ScoreBott);
            SaveSceneName();

            BottPlus += ScoreChangeEvent;
        }
        private void OnDisable()
        {
            BottPlus -= ScoreChangeEvent;
        }

        public override void ScoreChangeEvent()
        {
            _round += 1;
            _scoreBott += 1;

            PlayerPrefs.SetInt(KeyScore.Round, _round);
            PlayerPrefs.SetInt(KeyScore.ScoreBott, _scoreBott);
            SceneRestart.RestartScene();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PuckMoveAbility>())
            {
                EventActivate(_side);
            }
        }
        private void SaveSceneName()
        {
            _sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(KeyScore.SceneIndex, _sceneIndex);
        }

    }
}
