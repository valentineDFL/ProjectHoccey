using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _createInput;
    [SerializeField] private InputField _joinInput;

    void Start()
    {
        // Подключаемся к Photon, используя настройки из PhotonServerSettings
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
        }
        else
        {
            Debug.LogError("Not connected to Master Server or not ready. Wait for OnConnectedToMaster or OnJoinedLobby callback.");
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRoom(_joinInput.text);
        }
        else
        {
            Debug.LogError("Not connected to Master Server or not ready. Wait for OnConnectedToMaster or OnJoinedLobby callback.");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        // Теперь можно создавать и присоединяться к комнатам
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        PhotonNetwork.LoadLevel(6);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Create Room failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Join Room failed: " + message);
    }

    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
        PhotonNetwork.Disconnect();
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Disconnect();
    }
}