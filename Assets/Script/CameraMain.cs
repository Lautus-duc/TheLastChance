using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;



public class CameraMain : MonoBehaviour
{
    public CinemachineCamera cam;

    public Transform player;

    public Canvas canvas;

    [SerializeField]
    private int numberOfThePlayer = 1;


    private void Start()
    {
        if (cam != null && player != null)
        {
            cam.Follow = player;
        }
    }

    private void Update()
    {
        if (player == null)
        {
            ReassignCamera();
        }
    }

    public void ReassignCamera()
    {
        GameObject newPlayer = GameObject.FindWithTag("Player");

        if (newPlayer != null)
        {
            player = newPlayer.transform;
            cam.Follow = newPlayer.transform;
            player.GetComponent<PlayerStats>().NumberOfThePlayer = numberOfThePlayer;
        }
    }
}
