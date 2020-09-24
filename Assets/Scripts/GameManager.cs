using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PLAYING,
    MENU
}

public delegate void StateHandler();

public class GameManager : MonoBehaviour
{
    protected GameManager() {}
    private static GameManager _instance = null;
    public event StateHandler OnStateChange;

    public GameState gameState
    {
        get;
        private set;
    }

    private int _score;
    private int _timeMs;
    private int _diff;
    private int _numEnemies;

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
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
        MakePlayer();
    }

    void Exit()
    {
        GameManager.instance = null;
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
        Enemy.instance = new Enemy();
        _numEnemies++;
    }

    private void KilledEnemy()
    {
        Destroy(Enemy.instance);
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

        if(_timeMs % 10000 == 0)
        {
            _difficulty++;
        }

        if(_timeMs % (10000/_difficulty) == 0)
        {
            SpawnEnemy();
        }
    }
}