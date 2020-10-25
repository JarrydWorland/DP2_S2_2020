using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI message, highScore, score;
    
    public void OnReturnButtonClicked() => SceneManager.LoadScene("MainMenuScene");
}
