using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutWinnerName : MonoBehaviour
{
    [SerializeField] private Text _winner;
    
    // Start is called before the first frame update
    void Start()
    {
        _winner = GetComponent<Text>();
        string winner = PlayerPrefs.GetString(KeyScore.Winner);
        _winner.text = $"Congratulation Winner: {winner}";
        PlayerPrefs.DeleteKey(KeyScore.Round);
        PlayerPrefs.DeleteKey(KeyScore.ScoreBott);
        PlayerPrefs.DeleteKey(KeyScore.ScoreTop);
        PlayerPrefs.DeleteKey(KeyScore.Winner);
    }

}
