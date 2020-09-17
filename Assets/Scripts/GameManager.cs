using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score;
    private int _timeMs;
    private int _diff;
    private int _numEnemies;
    private GameObject _paused;

    private void MakePlayer()
    {
        // if game is not playing then remove player
        if (instance != null)
        {
            Destroy(gameObject);
        }
        // if game is paused keep player
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void SpawnEnemy()
    {
        // instantiate new enemy from enemy class
        Enemy _enemy = new Enemy();
        _numEnemies++;
    }

    private void KilledEnemy()
    {
        _numEnemies--;
        _score++;
        Destroy(gameObject);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        // disable scripts that still work while timescale is set to 0
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        // enable the scripts again
    }

    void Start()
    {
        pausePanel.SetActive(false);
        _timeMs = _score = 0;
        MakePlayer();
    }

    void Update()
    {
        if (true) // change this to when the menu opens or closes
        {
            if (!_paused.activeInHierarchy)
            {
                PauseGame();
            }
            if (_paused.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }

    // default 0.02s period (50 tick)
    void FixedUpdate()
    {
        _timeMs = _timeMs + 20;

        if(_timeMs % 10000 == 0)
        {
            _difficulty++;
        }

        if(_timeMs % (10000/_difficulty) == 0)
        {
            SpawnEnemy();
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public int TimeMs
    {
        get
        {
            return _timeMs;
        }
        set
        {
            _timeMs = value;
        }
    }
}
