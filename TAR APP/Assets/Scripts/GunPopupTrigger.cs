using UnityEngine;
using UnityEngine.InputSystem; // Required for New Input System

public class GunPopupTrigger : MonoBehaviour
{
    public GameObject popup;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // Make sure popup starts hidden
        if (popup != null)
            popup.SetActive(false);
    }

    void Update()
    {
        // --- Handle Touch Input (Android) ---
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            HandleClick(touchPos);
        }

        // --- Handle Mouse Input (Editor/PC Testing) ---
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            HandleClick(mousePos);
        }
    }

    void HandleClick(Vector2 screenPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if this gun object was clicked/tapped
            if (hit.transform == transform)
            {
                ToggleThisPopup();
            }
        }
        else
        {
            // Tapped empty area — close all popups
            CloseAllPopups();
        }
    }

    void ToggleThisPopup()
    {
        CloseAllPopups(); // Close others first

        if (popup != null)
        {
            popup.SetActive(!popup.activeSelf); // Toggle this popup
        }
    }

    void CloseAllPopups()
    {
        GameObject canvas = GameObject.Find("GunPopupCanvas");
        if (canvas != null)
        {
            foreach (Transform child in canvas.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
