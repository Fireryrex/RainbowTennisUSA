using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    public List<GameObject> powerUps;
    public float minNextSpawnSeconds;
    public float spawnTimeVarience;

    //list of possible sanw points with parallel array of bools for control
    private GameObject[] spawns;
    private bool[] activeSpawns;

    //privates for handling time between spawn
    private float lastSpawnSeconds;
    private float nextSpawnSeconds;

    //used for spawn transform selection
    private Transform selectionTransform;

    //flips off once all spawn points has 
    private bool canSpawnPowerup;

    private void Awake()
    {
        //get all the spawn points on the map
        spawns = GameObject.FindGameObjectsWithTag("PowerUpSpawn");


        activeSpawns = new bool[spawns.Length];
        //print("spawns: " + spawns.Length);
        //print("Activespawns: " + activeSpawns.Length);
        //set the active spawn array (this makes sure power ups don't spawn into each other)
        //(yes this is janky, no I don't know better)
        for (int i = 0; i < activeSpawns.Length; i++)
        {
            activeSpawns[i] = false;
        }

        //set the next power up spawn time in seconds
        nextSpawnSeconds = minNextSpawnSeconds + Random.Range(0, spawnTimeVarience);
        //print("Next spawn time: " + nextSpawnSeconds);

        //hey we can spawn stuff
        canSpawnPowerup = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //only  spawn when allowed, but change the time to spawn interval at every time to spawn interval
        if(Time.time >= nextSpawnSeconds)
        {
            if (canSpawnPowerup)
            {
               // print("spawnning at time: " + Time.time);
                //pic a random spawn transform
                bool hasSpawned = false;
                while (!hasSpawned)
                {
                    //pick WHERE I want to spawn
                    int toSpawn = Random.Range(0, spawns.Length - 1);
                    //if the spawn I want is active, just reloop and try again
                    if(activeSpawns[toSpawn])
                    {
                        continue;
                    }

                    else
                    {
                        //pick a random power-up, slap it on the spawn transffom.
                        Instantiate<GameObject>(powerUps[(int)Random.Range(0f, powerUps.Count - 1)], spawns[toSpawn].transform);
                        hasSpawned = true;
                        activeSpawns[toSpawn] = true;
                        print("I spawned!");
                    }
                    
                }

                //this block checks to see if every spawn point is occupied after an object is spawned
                int expectedSize = activeSpawns.Length;
                for (int i = 0; i < activeSpawns.Length; i++)
                {
                    if (activeSpawns[i] == true)
                    {
                        print(activeSpawns[i]);
                        expectedSize += 1;
                    }
                }

                print("active spawns: " + expectedSize);

                if (expectedSize == activeSpawns.Length)
                {
                    canSpawnPowerup = false;
                }
            }
            
            //set the next spawn time, do so regardless if there's a spawn otherwise objects will just spawn as soon as you get rid of one, and that bad.
            nextSpawnSeconds = Time.time + minNextSpawnSeconds + Random.Range(-spawnTimeVarience, spawnTimeVarience);
            //print("Next spawn time: " + nextSpawnSeconds);
        }                                            
    }        
}

