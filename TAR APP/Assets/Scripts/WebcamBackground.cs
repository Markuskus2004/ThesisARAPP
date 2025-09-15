using UnityEngine;

public class WebcamBackground : MonoBehaviour
{
    void Start()
    {
        WebCamTexture webcam = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcam;
        webcam.Play();
    }
}
