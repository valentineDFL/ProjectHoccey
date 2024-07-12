using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchDo(int numScene)
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }     
        SceneManager.LoadScene(numScene);
    }

    public void GetSceneNumber()
    {
        int sceneNumber = PlayerPrefs.GetInt(KeyScore.SceneIndex);
        SceneManager.LoadScene(sceneNumber);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
