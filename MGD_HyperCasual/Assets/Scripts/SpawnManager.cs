using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnPointY = 6;
    public float spawnPointX = -1.95f;
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;
    private car_Move playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("newestPlayerAsset").GetComponent<car_Move>();
        InvokeRepeating("SpawnRandomObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomObstacles()
    {
        if (playerControllerScript.stopScrolling == false)
        {
            int objectIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector2(Random.Range(spawnPointX, spawnPointX), spawnPointY);

            Instantiate(obstaclePrefabs[objectIndex], spawnPos, obstaclePrefabs[objectIndex].transform.rotation);
        }
        /*if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }*/
    }

}
