using Unity.Cinemachine;
using UnityEngine;
using Photon.Pun;



public class CameraMain : MonoBehaviourPun
{
    public CinemachineCamera cam;

    public Transform player;

    public Canvas canvas;

    [SerializeField]


    private void Start()
    {

        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
            GetComponent<PlayerMouvement>().enabled = false;
            cam.gameObject.SetActive(false); // Désactiver les caméras des autres joueurs
        }
        else
        {
            cam.Follow = player;
        }
    }
}
