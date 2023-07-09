using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider playerHitPoints;
    public SpawnManager spawnManager;
    public int maxHp;
    private GameManager isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = FindObjectOfType<GameManager>();
        playerHitPoints.maxValue = maxHp;
        playerHitPoints.value = maxHp;
        playerHitPoints.fillRect.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHitPlayer(int amount)
    {
        maxHp -= amount;
        playerHitPoints.fillRect.gameObject.SetActive(true);
        playerHitPoints.value = maxHp;

        if(maxHp == 0)
        {
            Destroy(gameObject);
            isGameOver.gameOver = true;
            spawnManager.CancelSpawn();
            Debug.Log("game phai dung lai");
        }
    }
}
