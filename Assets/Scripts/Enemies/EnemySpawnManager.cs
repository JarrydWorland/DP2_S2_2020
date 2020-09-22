using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawning of Enemies on request.
/// </summary>
public class EnemySpawnManager : SerializableSingleton<EnemySpawnManager>
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Serialized Fields----------------------------------------------------------------------------

    [SerializeField] private TextAsset waveDataFile;
    [SerializeField] private Vector3 spawnRotation;
    [SerializeField] private string testWaveId;
    [SerializeField] private bool testSpawnNow;

    //Non-Serialized Fields------------------------------------------------------------------------

    private Dictionary<string, List<SpawnData>> waveData;

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------                                                                                                                          
    
    /// <summary>
    /// Has the data detailing the waves of enemies been loaded successfully?
    /// </summary>
    public bool IsWaveDataLoaded { get => false; }

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        LoadWaveDataFromFile();
    }

    /// <summary>
    /// Loads the data on waves of enemies from the text file and saves them for later.
    /// </summary>
    private void LoadWaveDataFromFile()
    {
        if (waveDataFile == null)
        {
            Debug.LogError($"EnemySpawnManager is missing the wave data file.");
        }
        else
        {
            string[] data = waveDataFile.text.Split(new char[] { '\n' });
            waveData = new Dictionary<string, List<SpawnData>>();

            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];

                if (line[0] == '#')
                {
                    //Debug.Log($"Wave Data File, line {i + 1}: ignoring comment. Line is \"{line}\".");
                    continue;
                }

                string[] lineData = line.Split(new char[] { ':' });

                if (lineData.Length != 3)
                {
                    Debug.LogError($"Wave Data File, line {i + 1}: line must have 3 attributes, has {lineData.Length}. Line is \"{line}\".");
                    continue;
                }

                if (lineData[0] == "")
                {
                    Debug.LogError($"Wave Data File, line {i + 1}: wave ID must be specified. Line is \"{line}\".");
                    continue;
                }

                EEnemy type;

                switch (lineData[1])
                {
                    case "A20g":
                        type = EEnemy.A20g;
                        break;
                    case "C47a":
                        type = EEnemy.C47a;
                        break;
                    default:
                        type = EEnemy.None;
                        break;
                }

                if (type == EEnemy.None)
                {
                    Debug.LogError($"Wave Data File, line {i + 1}: enemy type {lineData[1]} is invalid. Line is \"{line}\".");
                    continue;
                }

                string[] coordinateData = lineData[2].Split(new char[] { ',' });

                if (coordinateData.Length != 3)
                {
                    Debug.LogError($"Wave Data File, line {i + 1}: position attribute must have 3 coordinates, has {coordinateData.Length}. Line is \"{line}\".");
                    continue;
                }

                float[] coordinates = new float[3];
                bool validPos = true;

                for (int j = 0; j < coordinateData.Length; j++)
                {
                    try
                    {
                        coordinates[j] = float.Parse(coordinateData[j], System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        validPos = false;
                        break;
                    }
                }

                if (!validPos)
                {
                    Debug.LogError($"Wave Data File, line {i + 1}: could not parse position coordinates \"{lineData[2]}\" as floats. Line is \"{line}\".");
                    continue;
                }

                Vector3 pos = new Vector3(coordinates[0], coordinates[1], coordinates[2]);

                //TODO: check that pos is within acceptable bounds

                if (!waveData.ContainsKey(lineData[0]))
                {
                    waveData[lineData[0]] = new List<SpawnData>();
                }

                waveData[lineData[0]].Add(new SpawnData(type, pos));
            }
        }
    }

    /// <summary>
    /// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
    /// Start() runs after Awake().
    /// </summary>
    private void Update()
    {
        //Testing only
        if (testSpawnNow)
        {
            testSpawnNow = false;
            SpawnWave(testWaveId);
        }
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Spawns a wave of enemies.
    /// </summary>
    /// <param name="id">The ID of the wave to be spawned.</param>
    public void SpawnWave(string id)
    {
        if (waveData.ContainsKey(id) && waveData[id].Count > 0)
        {
            foreach (SpawnData s in waveData[id])
            {
                Enemy enemy = EnemyFactory.Instance.Get(s.position, spawnRotation, s.type);
            }
        }
        else
        {
            Debug.LogError($"No wave data for wave {id}.");
        }
    }
}
