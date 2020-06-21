using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{


    //public Collider endTrigger;
    public GameObject ramp;
    public List<Transform> rampSpawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        allSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void allSpawner()
    {
        rampSpawner();
    }

    private void rampSpawner()
    {
        
        int spawnLimit = rampSpawnPoints.Count;

        List<bool> isSpawnedList = new List<bool>(new bool[spawnLimit]);
        int spawned = 0;
        int numberOfItemToSpawn = Random.Range(0, spawnLimit);
        //Debug.Log(isSpawnedList[0]);
        int spawnPos = 0;
        while(spawned <= numberOfItemToSpawn)
        {
            spawnPos = Random.Range(0, spawnLimit);
            if(isSpawnedList[spawnPos] != true)
            {
                Instantiate(ramp, rampSpawnPoints[spawnPos]).SetActive(true);
                isSpawnedList[spawnPos] = true;
                spawned++;
            }
            else
            {

            }
            
        }
        
    }
}
