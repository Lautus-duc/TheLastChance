using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Étape 1
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecté à Photon, on rejoint une room...");
        PhotonNetwork.JoinRandomRoom(); // Étape 2
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Pas de room trouvée, on en crée une.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 }); // Étape 3
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room rejointe, on instancie le joueur.");
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 1, 0), Quaternion.identity); // Étape 4
    }
}
