using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int Round = 0;
    private int ScoreBot = 0;
    private int ScoreTop = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();

        ScoreTop = PlayerPrefs.GetInt(KeyScore.ScoreTop);
        Round = PlayerPrefs.GetInt(KeyScore.Round) +1;
        ScoreBot = PlayerPrefs.GetInt(KeyScore.ScoreBott);

        string score = $"Top Score: {ScoreTop}\nBottom Score: {ScoreBot}\nRound: {Round}";
        
        _scoreText.text = score;
        
    }
}
