using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject itemPrefab;
    public GameObject finalFloor;
    public GameObject npc;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 0f;
    public float maxY = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        Vector3 randItem = new Vector3();
        Vector3 botFloor = new Vector3();
        Vector4 npcLoc = new Vector3();
        
        int num = Random.Range(10, numberOfPlatforms);
        

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y -= Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            if (i == num)
            {
                randItem.x = spawnPosition.x;
                randItem.y = spawnPosition.y + 2;
                Instantiate(itemPrefab, randItem, Quaternion.identity);
            }
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);          
        }
        botFloor.x = 0;
        botFloor.y = spawnPosition.y - 3;
        Instantiate(finalFloor, botFloor, Quaternion.identity);
        npcLoc.x = levelWidth + 2;
        npcLoc.y = spawnPosition.y - 2;
        Instantiate(npc, npcLoc, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
