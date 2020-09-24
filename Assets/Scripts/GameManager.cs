using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum so the game manager can easily reference and set the game state
public enum GameState
{
    PLAYING,
    MENU
}

// state change callback method
public delegate void StateHandler();

public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    private static GameManager _instance = null;
    public EnemySpawnManager _enemySpawnManager;
    public event StateHandler OnStateChange;

    public GameState gameState
    {
        get;
        private set;
    }

    // class internal variable declaration
    private int _score;
    private int _timeMs;
    private int _difficulty;
    private int _numEnemies;

    public static GameManager Instance
    {
        get
        {
            if (GameManager._instance == null)
            {
                DontDestroyOnLoad(GameManager._instance);
                GameManager._instance = new GameManager();
            }
            return GameManager._instance;
        }
    }

    public void SetState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    void Start()
    {
        _timeMs = _score = 0;
        _difficulty = 0;
        MakePlayer();
    }

    void Exit()
    {
        GameManager._instance = null;
    }

    private void MakePlayer()
    {
        // if game is not playing then remove player
        if (Player.instance == null)
        {
            Destroy(Player.instance);
        }
        // if game is paused keep player
        else
        {
            instance = this;
            DontDestroyOnLoad(Player.instance);
        }
    }

    private void SpawnEnemy()
    {

        _enemySpawnManager.SpawnWaveData();
        _numEnemies++;
    }

    private void KilledEnemy()
    {
        _numEnemies--;
        _score++;
    }

    private void PauseGame()
    {
        SetState(1);
    }

    private void ContinueGame()
    {
        SetState(0);
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

    void Update()
    {
        if (this.gameState == GameState.MENU) // change this to when the menu opens or closes
        {
            Time.timeScale = 0;

        }
        if (this.gameState == GameState.PLAYING)
        {
            Time.timeScale = 1;
        }
    }

    // default 0.02s period (50 tick)
    void FixedUpdate()
    {
        _timeMs = _timeMs + 20;

        if (_timeMs % 10000 == 0)
        {
            _difficulty++;
        }

        if (_timeMs % (10000 / _difficulty) == 0)
        {
            SpawnEnemy();
        }
    }
}