using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerPrint : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt(KeyScore.ScoreBott) == 3 || PlayerPrefs.GetInt(KeyScore.ScoreTop) == 3)
        {
            string res = "";
            res = (PlayerPrefs.GetInt(KeyScore.ScoreBott) > PlayerPrefs.GetInt(KeyScore.ScoreTop)) ? "Нижний" : "Верхний";
            PlayerPrefs.GetString(KeyScore.Winner, res);
            PlayerPrefs.SetString("Winner", res);

            SceneManager.LoadScene(2);

        }
    }
    
}
