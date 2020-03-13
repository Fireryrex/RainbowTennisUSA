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

    //privates for handling time between spawn
    private float lastSpawnSeconds;
    private float nextSpawnSeconds;

    //used for spawn transform selection
    private Transform selectionTransform;
    private bool canSpawn;

    private void Awake()
    {
        //get all the spawn points on the map
        spawns = GameObject.FindGameObjectsWithTag("PowerUpSpawn");
        makeNextTime();
        canSpawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //only  spawn when allowed, but change the time to spawn interval at every time to spawn interval
        if (Time.time >= nextSpawnSeconds && canSpawn)
        {
            //uses spawns[0] since there should only be one on the court. atleast there better be. 
            int powerUpPick = (int)Random.Range(0f, powerUps.Count - 1);
            print("Trying to spawn power up " + powerUpPick);
            GameObject newPowerup = Instantiate<GameObject>(powerUps[powerUpPick], spawns[0].transform.position, new Quaternion(0,0,0,0));
            print("I spawned!");
            newPowerup.transform.parent = this.gameObject.transform;
            canSpawn = false;
        }
    }                         
    
    //the spawn will trigger this when a power up is taken
    public void makeNextTime()
    {
        nextSpawnSeconds = Time.time + minNextSpawnSeconds + Random.Range(-spawnTimeVarience, spawnTimeVarience);
        print("Time: " + Time.time);
        print("Next time: " + nextSpawnSeconds);
    }
}

