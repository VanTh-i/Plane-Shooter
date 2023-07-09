using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rocketRB;
    private GameObject player;
    private Vector2 moveMent;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 findPlayer = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(findPlayer.y, findPlayer.x) * Mathf.Rad2Deg + 180;
        rocketRB.rotation = angle;
        moveMent = findPlayer;

        //transform.Translate(Vector3.left * speed * Time.deltaTime);
        //if (transform.position.y < -7)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void FixedUpdate()
    {
        MoveRocket(moveMent);
    }

    void MoveRocket(Vector2 findPlayer)
    {
        rocketRB.MovePosition((Vector2)transform.position + (findPlayer * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerHP>().EnemyHitPlayer(1);
        }
    }
}
