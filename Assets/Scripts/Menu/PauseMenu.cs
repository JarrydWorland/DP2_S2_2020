using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool IsPaused => pauseMenu.activeSelf;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) Continue();
            else Pause();
        }
    }

    private void Pause()
    {
        GameManager.Instance.PauseGame();
        pauseMenu.SetActive(true);
    }

    private void Continue()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.ContinueGame();
    }

    public void OnContinueButtonClicked() => Continue();
    public void OnReturnButtonClicked() => SceneManager.LoadScene("MainMenuScene");
}