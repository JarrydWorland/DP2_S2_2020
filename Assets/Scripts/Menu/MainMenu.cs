using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClicked() => SceneManager.LoadScene("main");
    public void OnExitButtonClicked() => Application.Quit();
}