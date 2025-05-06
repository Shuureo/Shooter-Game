using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks {


    void Start() {

        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {

        base.OnConnectedToMaster();

        Debug.Log("Connected to Server Successfully");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {

        base.OnJoinedLobby();

        SceneManager.LoadScene("MainMenu");

        Debug.Log("Successfully Connected to Room");
    }
}
