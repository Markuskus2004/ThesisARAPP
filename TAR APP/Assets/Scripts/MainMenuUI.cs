using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start button → loads your AR scene
    public void LoadARScene()
    {
        SceneManager.LoadScene("SampleScene"); // change "GunImages" to the exact AR scene name
    }

    // Library button → loads the library scene
    public void LoadLibraryScene()
    {
        SceneManager.LoadScene("LibraryScene");
    }

    // Exit button (works only in build, not in editor)
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
