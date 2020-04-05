using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public float bossCounter;
    public float spawnRate;

    public int bossSpawn;

    public int maxFrogs;

    public int maxBirds;

    public int maxDragonflys;

    public float dragonflyTimer;

    public int dragonflyRate;

    public int maxBirdSpawn;

    public int maxDragonflySpawn;

    public int maxFrogSpawn;

    private float spawnTimer;

    private int numDragonflys = 0;

    private int numBirds = 0;

    private int numFrogs = 0;

    void Start()
    {
        bossCounter = 0;
        spawnTimer = 0;
        spawnRate = 5;
        maxFrogs = 3;
        maxBirds = 3;
        maxDragonflys = 10;
        bossSpawn = 60; 
        dragonflyTimer = 0;
        dragonflyRate = 3;
        maxBirdSpawn = 2;
        maxFrogSpawn = 2;
        maxDragonflySpawn = 5;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        dragonflyTimer += Time.deltaTime;
        if(spawnTimer > spawnRate)
        {
            birds(GameObject.FindGameObjectsWithTag("Bird").Length);
            frogs(GameObject.FindGameObjectsWithTag("Frog").Length);
            spawnTimer = 0;
        }
        if(dragonflyTimer > dragonflyRate)
        {
            dragonflys(GameObject.FindGameObjectsWithTag("Dragonfly").Length);
            dragonflyTimer = 0;
        }
        if(bossCounter > bossSpawn && numBirds == 0 && numDragonflys == 0 && numFrogs == 0)
        {
            //Spawn boss
        }    
    }

    void birds(int num)
    {
        bossCounter += (numBirds - num);
        numBirds = num;
        while(numBirds < maxBirds)
        {
            //spawn bird
            numBirds++;
            if(numBirds - num >= maxBirdSpawn)
            {
                break;
            }
        }
    }

    void frogs(int num)
    {
        bossCounter += (numFrogs - num);
        numFrogs = num;
        while(numFrogs < maxFrogs)
        {
            //spawn frog
            numFrogs++;
            if(numFrogs - num >= maxFrogSpawn)
            {
                break;
            }
        }
    }

    void dragonflys(int num)
    {
        bossCounter += (numDragonflys - num) * 0.3f;
        numDragonflys = num;
        while(numDragonflys < maxDragonflys)
        {
            //spawn dragonfly
            numDragonflys++;
            if(numDragonflys - num >= maxDragonflySpawn)
            {
                break;
            }
        }
    }
}
