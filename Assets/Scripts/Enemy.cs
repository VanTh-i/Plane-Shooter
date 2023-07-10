using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject enemyBulletPrefab;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyBulletSpawn", 1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerHP>().EnemyHitPlayer(1);
        }
    }
    void EnemyBulletSpawn()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(enemyBulletPrefab, spawnPos, enemyBulletPrefab.transform.rotation);
    }
}
