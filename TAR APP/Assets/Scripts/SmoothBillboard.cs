using UnityEngine;

public class SmoothBillboard : MonoBehaviour
{
    private Camera arCamera;
    public float rotationSpeed = 5f; // higher = faster rotation

    void Start()
    {
        // Find the AR Camera in the scene
        arCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (arCamera != null)
        {
            // Desired direction to face
            Vector3 targetDirection = arCamera.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // Smoothly rotate toward camera
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
