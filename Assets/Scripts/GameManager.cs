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
    // object declaration and init
    [SerializeField] private GameObject Player;
    protected GameManager() { }
    private static GameManager instance;
    public event StateHandler OnStateChange;

    // our game state enum interaction for the manager
    public GameState gameState
    {
        get;
        private set;
    }

    // class internal variable declaration
    private int _score;
    private int _timeMs;
    private int _difficulty;
    private int _enemyWaveId;

    // creates the game manager instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                DontDestroyOnLoad(instance);
                instance = new GameManager();
            }
            return instance;
        }
    }

    // function to set state
    public void SetState(GameState state)
    {
        gameState = state;
        this.OnStateChange(); // callback on state change
    }

    // unity start function
    void Start()
    {
        // some initial values
        _timeMs = _score = 0;
        _difficulty = 1;
        MakePlayer(); // calls the make player function
    }

    // unity on exit function
    void Exit()
    {
        instance = null;
    }

    private void MakePlayer()
    {
        // if game is not playing then remove player
        if (Player == null)
        {
            Destroy(Player);
        }
        // if game is paused keep player
        else
        {
            instance = this;
            DontDestroyOnLoad(Player);
        }
    }

    // spawns wave from enemy spawn manager
    private void SpawnEnemy()
    {
        EnemySpawnManager.Instance.SpawnWave(_enemyWaveId.ToString());
        _enemyWaveId++;
    }

    // called from enemy class when player kills enemy
    private void PlayerKilledEnemy()
    {
        _score++;
    }

    // sets game state to menu/paused
    private void PauseGame()
    {
        SetState(GameState.MENU);
    }

    // sets game state to active/playing
    private void ContinueGame()
    {
        SetState(GameState.PLAYING);
    }

    // getter and setter for score
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

    // getter and setter for time
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

    // constantly checks the game state to see if the menu is up
    void Update()
    {
        if (gameState == GameState.MENU) // change this to when the menu opens or closes
        {
            Time.timeScale = 0;

        }
        if (gameState == GameState.PLAYING)
        {
            Time.timeScale = 1;
        }
    }

    // default 0.02s period (50 tick) to suss out the difficulty with respect to time
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