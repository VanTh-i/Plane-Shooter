using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public bool gameOver = false;
    public GameObject powerUpIcon;
    public GameObject playerAgain;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        //GameOver();
        if (gameOver == true)
        {
            powerUpIcon.SetActive(false);
            playerAgain.SetActive(true);
        }
    }
    void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("PlaneShooter");
    }

}
