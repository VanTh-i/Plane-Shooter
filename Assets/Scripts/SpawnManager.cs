using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnEnemy;
    public GameObject powerUpPrefabs;
    private float spawnDelay = 1f;
    private float spawnInterval = 3f;
    private float spawnPosX = 1.9f;
    private float spawnPosY = 7;
    private float pwUpspawnDelay = 5f;
    private float pwUpspawnInterval = 25f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUp", pwUpspawnDelay, pwUpspawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, spawnEnemy.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, 0);
        Instantiate(spawnEnemy[enemyIndex], spawnPos, spawnEnemy[enemyIndex].transform.rotation);
    }
    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, 0);
        Instantiate(powerUpPrefabs, spawnPos, powerUpPrefabs.transform.rotation);
    }
}
