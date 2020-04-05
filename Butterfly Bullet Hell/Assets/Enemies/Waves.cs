using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject bird;
    public GameObject frog;
    public GameObject dragonfly;
    //Left edge of where enemies spawn
    public float leftEdge = -8;
    //Right edge of where enemies spawn
    public float rightEdge = 8;
    public float enemyZ = 0;
    public float birdHeight = 4;
    // Start is called before the first frame update
    void Start()
    {
        float space = Mathf.Abs(leftEdge) + Mathf.Abs(rightEdge);
    }
    public void spawnBird(bool direction, float x, float y)
    {
        GameObject bir = Instantiate(bird);
        bird.transform.position = new Vector3(x, y, enemyZ);
        bird.GetComponent<birdMovement>().moveRight = direction;
    }
    public void spawnFrog(float x, float y)
    {
        Instantiate(frog);
        frog.transform.position = new Vector3(x, y, enemyZ);
    }
    public void spawnDragonFly(float x, float y)
    {
        Instantiate(dragonfly);
        dragonfly.transform.position = new Vector3(x, y, enemyZ);
    }
    //Spawns birds in a line with given direction(right true left false), space between them, midpoint of the line and number of birds.
    public void birdLine(bool direction, float spacing, float middle, int number)
    {
        int count = 1;
        if (number % 2 == 0)
        {
            for (int i = 0; i < number; i++)
            {
                if (i % 2 == 0)
                {
                    spawnBird(direction, middle + count * spacing, birdHeight);
                }
                else
                {
                    spawnBird(direction, (middle + spacing) - count * spacing, birdHeight);
                    count++;
                }
            }

        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                if (i == 0)
                {
                    spawnBird(direction, middle, birdHeight);
                }
                else if (i % 2 == 1)
                {
                    spawnBird(direction, middle + count * spacing, birdHeight);
                }
                else
                {
                    spawnBird(direction, middle - count * spacing, birdHeight);
                    count++;
                }
            }
        }
    }
}
