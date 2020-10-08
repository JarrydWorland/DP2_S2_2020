using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClicked() => SceneManager.LoadScene("main");
    public void OnScoreButtonClicked() => SceneManager.LoadScene("ScoreMenu");
    public void OnExitButtonClicked() => Application.Quit();
}