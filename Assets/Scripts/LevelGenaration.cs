using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenaration : MonoBehaviour
{

    public Transform startPosTransform;
    public GameObject roadTile;
    public Transform tileHolder;
    public float tileDistance;

    public int maxTileCount;
    public int currentTileCount;
    public Vector3 newGenPos;
    public Vector3 oldGenPos;

    public List<GameObject> spawnedTileList;
    public int spawnedTileCount;




    private GameObject tmpTile;




    // Start is called before the first frame update
    void Start()
    {
        startTileGenaration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startTileGenaration()
    {
        newGenPos = startPosTransform.position;

        for(int count = 0; count < maxTileCount; count++)
        {
            spawnTile();
        }
    }

    private void spawnTile()
    {
        tmpTile = Instantiate(roadTile, newGenPos, Quaternion.identity, tileHolder);
        tmpTile.SetActive(true);
        spawnedTileList.Add(tmpTile);
        spawnedTileCount++;
        oldGenPos = newGenPos;
        newGenPos += new Vector3(0, 0, tileDistance);
    }

    public void deleteTile()
    {
        Destroy(spawnedTileList[0]);
        spawnedTileList.RemoveAt(0);
        spawnedTileCount--;
        spawnTile();
    }

}
