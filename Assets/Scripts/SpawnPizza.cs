using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPizza : MonoBehaviour
{
    public GameObject pizza;
    public Transform BorderLeft, BorderRight, BorderTop, BorderBottom;


    public float spawnDelay;
    public int points;
  

    void Start()
    {
        //for spawning the pizza in every spawnRate
        InvokeRepeating("Spawner", 4, spawnDelay);
    }


    void Spawner() {
        int x=0, y=0;
        //find position within the border to spawn the food i.e pizza
        x = (int)Random.Range(BorderLeft.position.x + 4f, BorderRight.position.x - 5f);
        y = (int)Random.Range(BorderTop.position.y - 5f, BorderBottom.position.y + 5f);
        
        //spawn pizza
        Instantiate(pizza, new Vector2(x, y), transform.rotation);
    }
}
