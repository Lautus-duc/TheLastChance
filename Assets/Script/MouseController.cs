using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            //Debug.Log("Left mouse button pressed");
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            //Debug.Log("Right mouse button pressed");
        }
    }
}
