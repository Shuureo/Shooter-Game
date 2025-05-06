using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour {

    // This script is to spawn in the player (Multiplayer)

    [Header("Spawn Object")]
    public GameObject playerPrefab;

    [Header("Values")] // These values are to mark where the player can spawn
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float minY;
    public float maxY;

    private void Start() {

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY)); // This picks a random area within the chosen min/max values
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        // Disable the camera for all players except the local player
        if (!player.GetComponent<PhotonView>().IsMine) {
            Camera camera = player.GetComponentInChildren<Camera>();
            if (camera != null) {
                camera.gameObject.SetActive(false);
            }
        }
    }
}
