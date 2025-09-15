using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SingleGunPopup : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    [System.Serializable]
    public class GunPopupEntry
    {
        public string imageName;        // Name from Reference Image Library (must match exactly!)
        public GameObject popupPrefab;  // Prefab for this gun's flashcard
    }

    public List<GunPopupEntry> gunPopups = new List<GunPopupEntry>();

    private GameObject activePopup;

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log("📸 Detected new image: " + trackedImage.referenceImage.name);
            ShowPopup(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            Debug.Log("🔄 Updated tracking: " + trackedImage.referenceImage.name + " | State: " + trackedImage.trackingState);
            if (activePopup != null)
            {
                activePopup.transform.position = trackedImage.transform.position + new Vector3(0, 0.05f, 0);
                activePopup.SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }
        }

        foreach (var trackedImage in args.removed)
        {
            Debug.Log("❌ Lost tracking: " + trackedImage.referenceImage.name);
            if (activePopup != null)
            {
                Destroy(activePopup);
                activePopup = null;
            }
        }
    }

    private void ShowPopup(ARTrackedImage trackedImage)
    {
        Debug.Log("Detected image: " + trackedImage.referenceImage.name);

        foreach (var entry in gunPopups)
        {
            if (entry.imageName == trackedImage.referenceImage.name)
            {
                Debug.Log("Instantiating popup: " + entry.imageName);
                activePopup = Instantiate(entry.popupPrefab,
                                          trackedImage.transform.position + new Vector3(0, 0.05f, 0),
                                          Quaternion.identity);

                activePopup.transform.SetParent(trackedImage.transform);
                return;
            }
        }
    }

}

