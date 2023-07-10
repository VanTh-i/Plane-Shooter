using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnEnemy;
    public GameObject powerUpPrefabs;
    public GameObject bulletPrefabs;

    private GameObject player;
    private PlayerController getHasPowerUp;
    private float spawnPosX = 1.9f;
    private float spawnPosY = 7;

    private void Awake()
    {
        getHasPowerUp = FindObjectOfType<PlayerController>();
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
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
    void BulletSpawn()
    {
        Vector3 spawnPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        
        if (getHasPowerUp.hasPowerUp)
        {
            Instantiate(bulletPrefabs, player.transform.position + new Vector3(0, 0.5f, 0), bulletPrefabs.transform.rotation);
            Instantiate(bulletPrefabs, player.transform.position + new Vector3(-0.4f, 0.5f, 0), bulletPrefabs.transform.rotation);
            Instantiate(bulletPrefabs, player.transform.position + new Vector3(0.4f, 0.5f, 0), bulletPrefabs.transform.rotation);
        }
        else
        {
            Instantiate(bulletPrefabs, spawnPos, bulletPrefabs.transform.rotation);
        }
    }
    //void EnemyBulletSpawn()
    //{
    //    Vector3 spawnPos = new Vector3(enemy.transform.position.x , enemy.transform.position.y, 0);
    //    Instantiate(enemyBulletPrefabs, spawnPos, enemyBulletPrefabs.transform.rotation);
    //}
    void Spawn()
    {
        InvokeRepeating("SpawnRandomEnemy", 1f, 1.5f);
        InvokeRepeating("SpawnPowerUp", 5f, 25f);
        InvokeRepeating("BulletSpawn", 0, 0.5f);
        //InvokeRepeating("EnemyBulletSpawn", 1f, 1f);
    }
    public void CancelSpawn()
    {
        CancelInvoke("SpawnRandomEnemy");
        CancelInvoke("SpawnPowerUp");
        CancelInvoke("BulletSpawn");
    }
}
