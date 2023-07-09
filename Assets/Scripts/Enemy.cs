using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnManager.instance.EnemyBulletSpawn(transform.position));
        //SpawnManager.instance.EnemyBulletSpawn(transform.position);
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
}
