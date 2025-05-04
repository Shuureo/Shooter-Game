using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks {

    public GameObject player;

    public Transform spawnPoint;

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

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("Successfully Connected to Room");
    }

    public override void OnJoinedRoom() {

        base.OnJoinedRoom();

        Debug.Log("Joined Room");

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    }
}
