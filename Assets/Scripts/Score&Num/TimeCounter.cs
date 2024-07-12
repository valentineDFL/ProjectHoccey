using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon;
using Photon.Pun;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    private float _count = 120;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsConnected)
        {
            TimePassage();
        }
        else if(PhotonNetwork.CountOfPlayers == 2)
        {
            TimePassage();
        }
    }

    private void TimePassage()
    {
        int minutes = Mathf.FloorToInt(_count / 60f);
        int seconds = Mathf.FloorToInt(_count % 60f);


        if (minutes == 0 && seconds == 0)
        {
            _count = 120;
        }

        _count -= Time.deltaTime;
        string timer;

        if (seconds > 9)
        {
            timer = $"Round Time Remaining: 0{minutes}:{seconds}";
        }
        else
        {
            timer = $"Round Time Remaining: 0{minutes}:0{seconds}";
        }
        _text.text = timer;
    }

}
