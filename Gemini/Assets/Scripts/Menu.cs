using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour // Assuming this script is attached to a GameObject in the StartMenu scene
{
    public void ExitGame()
    {
        // Exit the application
        Application.Quit();
    }

    public void LoadLevelScene()
    {
        // Load the "Level" scene using SceneManager
        SceneManager.LoadScene("Level");
    }
}
