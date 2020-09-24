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
    protected GameManager() { }
    private static GameManager _instance = null;
    public EnemySpawnManager enemySpawnManager;
    public GameObject player;
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
    private int _numEnemies;

    // creates the game manager instance
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

    // function to set state
    public void SetState(GameState state)
    {
        this.gameState = state;
        this.OnStateChange(); // callback on state change
    }

    // unity start function
    void Start()
    {
        // some initial values
        _timeMs = _score = 0;
        _difficulty = 0;
        this.MakePlayer(); // calls the make player function
    }

    // unity on exit function
    void Exit()
    {
        GameManager._instance = null;
    }

    private void MakePlayer()
    {
        // if game is not playing then remove player
        if (GameObject.player == null)
        {
            Destroy(GameObject.player);
        }
        // if game is paused keep player
        else
        {
            instance = this;
            DontDestroyOnLoad(GameObject.player);
        }
    }

    // spawns wave from enemy spawn manager
    private void SpawnEnemy()
    {
        enemySpawnManager.SpawnWave(_numEnemies);
        _numEnemies++;
    }

    // adjusts game manager parameters and adjusts 
    private void KilledEnemy()
    {
        _numEnemies--;
        _score++;
    }

    // sets game state to menu/paused
    private void PauseGame()
    {
        SetState(1);
    }

    // sets game state to active/playing
    private void ContinueGame()
    {
        SetState(0);
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
        if (this.gameState == GameState.MENU) // change this to when the menu opens or closes
        {
            Time.timeScale = 0;

        }
        if (this.gameState == GameState.PLAYING)
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