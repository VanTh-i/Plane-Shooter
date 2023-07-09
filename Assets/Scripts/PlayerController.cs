using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletpPrefabs;
    public GameObject powerUpIcon;
    public float speed;
    public bool hasPowerUp;
    private float horizontalInput;
    private float verticalInput;
    private float boundX = 2f;
    private float boundY = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void LateUpdate()
    {
        if (transform.position.x < -boundX)
        {
            transform.position = new Vector3(-boundX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > boundX)
        {
            transform.position = new Vector3(boundX, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -boundY)
        {
            transform.position = new Vector3(transform.position.x, -boundY, transform.position.z);
        }
        if (transform.position.y > boundY)
        {
            transform.position = new Vector3(transform.position.x, boundY, transform.position.z);
        }

        powerUpIcon.transform.position = transform.position + new Vector3(0.7f, -0.4f, 0);
    }
    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        //ban bang nut space
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(bulletpPrefabs, transform.position + new Vector3(0, 0.5f, 0), bulletpPrefabs.transform.rotation);
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && hasPowerUp)
        //{
        //    Instantiate(bulletpPrefabs, transform.position + new Vector3(0, 0.5f, 0), bulletpPrefabs.transform.rotation);
        //    Instantiate(bulletpPrefabs, transform.position + new Vector3(-0.4f, 0.5f, 0), bulletpPrefabs.transform.rotation);
        //    Instantiate(bulletpPrefabs, transform.position + new Vector3(0.4f, 0.5f, 0), bulletpPrefabs.transform.rotation);
        //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(collision.gameObject);
            powerUpIcon.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdown());
        }
    }
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpIcon.gameObject.SetActive(false);
    }
}
