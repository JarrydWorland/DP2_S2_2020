using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private float _speed;

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

        _speed = Player_Movement.Instance.Speed;
        Player_Movement.Instance.Speed = 0.0f;
    }

    private void Continue()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.ContinueGame();

        Player_Movement.Instance.Speed = _speed;
    }

    public void OnContinueButtonClicked() => Continue();
    public void OnReturnButtonClicked() => SceneManager.LoadScene("MainMenuScene");
}