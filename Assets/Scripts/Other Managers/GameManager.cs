using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private int numWaves;
    [SerializeField] private AudioSource musicSource;
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
                instance = new GameManager();
            }
            return instance;
        }
    }

    // function to set state
    public void SetState(GameState state)
    {
        gameState = state;
        OnStateChange?.Invoke(); // callback on state change
    }

    // unity awake function
    void Awake()
    {
        // some initial values
        Time.timeScale = 1.0f;
        _timeMs = 0;
        _difficulty = 1;
    }

    // unity start function
    void Start()
    {
        ScoreManager.instance.ResetScore();
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
            ScoreManager.instance.ResetScore();
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
        _enemyWaveId++;
        EnemySpawnManager.Instance.SpawnWave(_enemyWaveId.ToString());
    }

    // sets game state to menu/paused
    public void PauseGame()
    {
        SetState(GameState.MENU);
        Time.timeScale = 0.0f;
    }

    // sets game state to active/playing
    public void ContinueGame()
    {
        SetState(GameState.PLAYING);
        Time.timeScale = 1.0f;
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

    // default 0.02s period (50 tick) to suss out the difficulty with respect to time
    void FixedUpdate()
    {
        _timeMs = _timeMs + 20;

        if (_timeMs % 10000 == 0)
        {
            _difficulty++;
        }

        if (numWaves > 0 && _enemyWaveId < numWaves && EnemyManager.Instance.Enemies.Count == 0)
        {
            SpawnEnemy();
        }

        if (_enemyWaveId >= numWaves && EnemyManager.Instance.Enemies.Count == 0 || PlayerHealthController.Instance.Health.CurrentHealth == 0)
        {
            // https://www.codedojo.com/?p=2155
            
            GameObject FindObjectInChildren(GameObject obj, string objectName)
            {
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    GameObject childObj = obj.transform.GetChild(i).gameObject;
                    if (childObj.name == objectName) return childObj;
                    
                    GameObject foundObj = FindObjectInChildren(childObj, objectName);
                    if (foundObj != null) return foundObj;
                }

                return null;
            }

            GameObject FindObject(string objectName)
            {
                GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

                foreach (GameObject obj in rootObjects)
                {
                    if (obj.transform.gameObject.name == objectName) return obj.transform.gameObject;
                    
                    GameObject foundObj = FindObjectInChildren(obj, objectName);
                    if (foundObj != null) return foundObj;
                }

                return null;
            }

            FindObject("GameOverMenu")?.SetActive(true);

            GameOverMenu gameOverMenu = FindObjectOfType<GameOverMenu>();
            
            gameOverMenu.message.text = PlayerHealthController.Instance.Health.CurrentHealth > 0 ? "You win!" : "You lose!";
            gameOverMenu.highScore.text = "High score: " + ScoreManager.highScore;
            gameOverMenu.score.text = "Score: " + ScoreManager.score;

            PauseGame();
        }
    }
}