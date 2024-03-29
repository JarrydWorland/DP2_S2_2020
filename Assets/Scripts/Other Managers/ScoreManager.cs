﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public static int score, highScore;

    public TextMeshProUGUI scoreText, highScoreText, gameOverScoreText;

    void Awake()
    {
        instance = this;

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = highScore.ToString();
        }
    }

    public void AddScore()
    {
        score++;
        UpdateHighScore();

        scoreText.text = score.ToString();
        //gameOverScoreText.text = score.ToString();
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;

            highScoreText.text = highScore.ToString();

            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
        //gameOverScoreText.text = score.ToString();
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");

        highScore = 0;
        highScoreText.text = highScore.ToString();
    }
}
