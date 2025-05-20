using UnityEngine;

public class CameraAfterDeath : MonoBehaviour
{
    public float lifetime = 6.4f;
    public float upwardDriftSpeed = 0.5f;

    private void Update()
    {
        transform.position += Vector3.up * upwardDriftSpeed * Time.deltaTime;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
