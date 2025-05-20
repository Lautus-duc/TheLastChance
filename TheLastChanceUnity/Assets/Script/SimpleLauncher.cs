using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SimpleLauncher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connexion à Photon
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom(); // Essaye de rejoindre une salle
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 }); // Sinon, crée une nouvelle salle
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connecté à la salle !");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity); // Instancie ton prefab joueur
    }
}
