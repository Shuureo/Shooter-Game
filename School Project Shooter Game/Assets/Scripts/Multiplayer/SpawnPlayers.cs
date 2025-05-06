using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour {

    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float minY;
    public float maxY;

    private void Start() {

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}
