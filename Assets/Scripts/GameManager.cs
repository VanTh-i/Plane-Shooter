using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
