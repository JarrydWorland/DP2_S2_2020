using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public void MainMenu() => SceneManager.LoadScene("MainMenuScene");
    public void MenuClearHighScore() => ScoreManager.instance.ClearHighScore();
}