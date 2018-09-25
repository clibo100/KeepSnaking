using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject timerText;
    public GameObject scoreText;

    public SpawnObject spawnfood;
    public SpawnObject spawnobstacles;
    public SnakeMovement sm;

    private float timer;

    private int score = 0;
    private int collected = 0;

	// Use this for initialization
	void Start () {
        timerText.GetComponent<Text>().text = "hello";
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timerText.GetComponent<Text>().text = Mathf.Round(timer).ToString();

        if (int.Parse(timerText.GetComponent<Text>().text) >= 30)
        {
            sm.Die();
        }
    }

    public void AddScore()
    {
        score += 1;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    public void AddCollected()
    {
        collected += 1; 
        if (collected == 3)
        {
            spawnfood.SpawnFood();
            spawnobstacles.SpawnFood();
            timer = 0; 

            collected = 0;
        }
    }

    public void SpawnSingleFood()
    {
        spawnfood.SpawnSingleObject();
    }

    public void SpawnSingleObstacle()
    {
        spawnobstacles.SpawnSingleObject();
    }
}
