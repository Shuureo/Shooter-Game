using UnityEngine;
using Photon.Pun;

public class DeactivateCameraIfNotMine : MonoBehaviourPunCallbacks {

    // This script is to DEACTIVATE THE FUCKING SHIT CAMERAS, THAT I USED HOURS TO FIX, AND THE INTERNET HAD NO ANSWERS, CHATGPT HAD NO ANSWERS. THIS THING ALONE IS WHY I NOW HATE MAKING MULTIPLAYER (Atleast it'll be easier next time lol)

    void Start() {

        if(!photonView.IsMine) {

            gameObject.SetActive(false);
        }
    }
}
