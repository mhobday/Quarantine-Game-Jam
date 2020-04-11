using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerScripts : MonoBehaviour
{
    public GameObject bird;
    public GameObject frog;
    public GameObject downDragonfly;

    public GameObject rightDragonfly;

    public GameObject leftDragonfly;

    public GameObject crossLeftDragonfly;

    public GameObject crossRightDragonfly;

    public int leftEdge = -8;
    //Right edge of where enemies spawn
    public int rightEdge = 8;
    public float enemyZ = 0;

    public float frogY = 4.5f;
    public float birdHeight = 4;
    
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

    public GameObject spawn;

    public float spawnTimer;

    public int numDragonflys = 0;

    private int numBirds = 0;

    private int numFrogs = 0;

    private MonoBehaviour wave;

    public int score;
    

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
        leftEdge = -8;
    //Right edge of where enemies spawn
        rightEdge = 8;
        enemyZ = 0;

        frogY = 4.5f;
        birdHeight = 4;
        //wave = GetComponent<Waves>();
        score = 0;


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
            spawnRate -= 0.05f;
        }
        if(dragonflyTimer > dragonflyRate)
        {
            dragonflys(GameObject.FindGameObjectsWithTag("Dragonfly").Length);
            dragonflyTimer = 0;
            spawnRate -= 0.05f;
        }

        if(bossCounter > bossSpawn && numBirds == 0 && numDragonflys == 0 && numFrogs == 0)
        {
            //Spawn boss
        }    
    }

    void birds(int num)
    {
        numBirds = num;
        int [] used = {-8, -8};
        int counter = 0;
        while(numBirds < maxBirds)
        {
            used[counter] = Random.Range(-7,7);
            while(used[1] != -8 && used[0] == used[1])
            {
                used[1] = Random.Range(-7,7);
            }
            spawnBird(true, used[counter]);
            counter++;
            numBirds++;
            score++;
            if(numBirds - num >= maxBirdSpawn)
            {
                break;
            }
        }
    }

    void frogs(int num)
    {
        numFrogs = num;
        int [] used = {-8, -8};
        int counter = 0;
        while(numFrogs < maxFrogs)
        {
            used[counter] = Random.Range(-7,7);
            while(used[1] != -8 && used[0] == used[1])
            {
                used[1] = Random.Range(-7,7);
            }
            spawnFrog(used[counter]);
            counter++;
            numFrogs++;
            score++;
            if(numFrogs - num >= maxFrogSpawn)
            {
                break;
            }
        }
    }

    void dragonflys(int num)
    {
        numDragonflys = num;
        int dragonflyDirection = Random.Range(1,5);
        int numDragonflysSpawn = Random.Range(2,5);
        int used = 0;
        int l = leftEdge;
        int r = rightEdge;
        if(dragonflyDirection == 4 || dragonflyDirection == 5)
        {
            used = Random.Range(0,4);
        }
        else if(dragonflyDirection == 1)
        {
            used = Random.Range(-7, 3);    
        }
        else
        {
            used = Random.Range(-4, 0);
        }   
        while(numDragonflys < maxDragonflys)
        {
            if(dragonflyDirection == 4)
            {
                dragonflySwitch(dragonflyDirection,l, used);
                if(used < 5)
                {
                    used++;
                }
                else
                {
                    l++;
                }
            }
            else if(dragonflyDirection == 5)
            {
                dragonflySwitch(dragonflyDirection, r, used);
                if(used < 5)
                {
                    used++;
                }
                else
                {
                    l++;
                }
            }
            else if(dragonflyDirection == 1)
            {
                dragonflySwitch(dragonflyDirection, used, 0);
                used++;
            }
            else
            {
                dragonflySwitch(dragonflyDirection, 0, used);
                used++;
            }
            numDragonflys++;
            score++;
            if(numDragonflys - num >= numDragonflysSpawn)
            {
                break;
            }
        }
    }

    public void spawnBird(bool moveRight, float x)
    {
        Instantiate(bird);
        bird.transform.position = new Vector3(x, 4f, enemyZ);
        bird.GetComponent<birdMovement>().moveRight = moveRight;
    }
    public void spawnFrog(float x)
    {
        Instantiate(frog);
        frog.transform.position = new Vector3(x, frogY, enemyZ);
        frog.gameObject.GetComponent<turretAim>().player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    public void spawnDownDragonFly(float x, float y)
    {
        Instantiate(downDragonfly);
        downDragonfly.transform.position = new Vector3(x, y, enemyZ);
    }

    public void spawnRightDragonFly(float x, float y)
    {
        Instantiate(rightDragonfly);
        rightDragonfly.transform.position = new Vector3(x, y, enemyZ);
    }

    public void spawnLeftDragonFly(float x, float y)
    {
        Instantiate(leftDragonfly);
        leftDragonfly.transform.position = new Vector3(x, y, enemyZ);
    }

    public void spawnCrossRightDragonFly(float x, float y)
    {
        Instantiate(crossRightDragonfly);
        crossRightDragonfly.transform.position = new Vector3(x, y, enemyZ);
    }

    public void spawnCrossLeftDragonFly(float x, float y)
    {
        Instantiate(crossLeftDragonfly);
        crossLeftDragonfly.transform.position = new Vector3(x, y, enemyZ);
    }

    private void dragonflySwitch(int num, int randomNumX, int randomNumY)
    {
        switch(num)
        {
            case 1:
                spawnDownDragonFly(randomNumX, frogY);
                break;
            case 2:
                spawnRightDragonFly(leftEdge, randomNumY);
                break;
            case 3:
                spawnLeftDragonFly(rightEdge, randomNumY);
                break;
            case 4:
                spawnCrossRightDragonFly(randomNumX, randomNumY);
                break;
            default:
                spawnCrossLeftDragonFly(randomNumX, randomNumY);
                break;

        }    

    }
}
