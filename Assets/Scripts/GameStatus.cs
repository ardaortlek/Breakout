using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int playerScore = 0;
    [SerializeField] int pointsPerBlock = 30;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numberOfTypes = FindObjectsOfType<GameStatus>().Length;
        if(numberOfTypes > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addScore()
    {
        playerScore = playerScore + pointsPerBlock;
        scoreText.text = playerScore.ToString();
        //gameSpeed = gameSpeed + 0.01f;
        pointsPerBlock = pointsPerBlock + 5;

    }

    public void resetTheScore()
    {
        Destroy(gameObject);
    }
}
