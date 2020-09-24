using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Enter the play scene, disposing of any existing play scene.
    public void OnPlayButtonClicked()
    {
        if (SceneManager.GetSceneByName("main").isLoaded) SceneManager.UnloadSceneAsync("main");
        SceneManager.LoadScene("main");
    }

    // Exit the application.
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    // Enter the existing play scene.
    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene("main");
    }

    // Enter the main menu scene and dispose of the existing play scene.
    public void OnReturnButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
        SceneManager.UnloadSceneAsync("main");
    }

    // Check for key input.
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == "main") SceneManager.LoadScene("PauseScene");
            else if (currentSceneName == "PauseScene") SceneManager.LoadScene("main");
        }
    }
}