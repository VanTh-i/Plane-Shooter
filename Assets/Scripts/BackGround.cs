using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private float speed = 0.2f;
    private GameManager isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
        if (isGameOver.gameOver == true)
        {
            speed = 0f;
        }
    }
}
