using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // ✅ new Input System

public class SceneLoaderTrigger : MonoBehaviour
{
    void Update()
    {
        // --- Touchscreen (Phone/Tablet) ---
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            HandleClick(Touchscreen.current.primaryTouch.position.ReadValue());
        }

        // --- Mouse (PC Editor Testing) ---
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick(Mouse.current.position.ReadValue());
        }
    }

    void HandleClick(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit object: " + hit.transform.name);

            // If THIS button is clicked, go back to menu
            if (hit.transform == transform)
            {
                Debug.Log("Loading MainMenu...");
                SceneManager.LoadScene("MainMenu"); // make sure scene name matches!
            }
        }
    }
}
