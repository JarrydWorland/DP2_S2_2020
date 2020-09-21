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
        //if text file is null

            //Error message

        //else

            //Load text file

            //for each line

                //if line is comment

                    //ignore

                //else if line is invalid

                    //Error message

                //else
                
                    //Translate line to spawn data

                    //Add spawn data to list
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Spawns a wave of enemies.
    /// </summary>
    /// <param name="id">The ID of the wave to be spawned.</param>
    public void SpawnWave(string id)
    {
        //if dictionary has non-empty list matching id
        
            //for each spawn data

                //Instantiate enemy according to spawn data via EnemyFactory

        //else

            //Error message
    }
}
