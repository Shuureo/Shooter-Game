using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks {

    // This script is for creating and joining multiplayer rooms

    [Header("Input Fields (The areas you write room names)")]
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public void CreateRoom() {

        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom() {

        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom() {

        base.OnJoinedRoom();

        Debug.Log("Joined Room");

        PhotonNetwork.LoadLevel("MultiplayerRoom");
    }

}
