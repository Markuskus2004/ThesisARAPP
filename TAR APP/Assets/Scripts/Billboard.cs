using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera arCamera;

    void Start()
    {
        // Find the AR Camera in the scene
        arCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (arCamera != null)
        {
            // Make the object face the camera
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                             arCamera.transform.rotation * Vector3.up);
        }
    }
}
