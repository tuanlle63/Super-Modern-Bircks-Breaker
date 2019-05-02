﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberofbricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberofbricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;

    }

    public void UpdateScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score;

    }

    public void UpdateNumberOfBricks()
    {
        numberofbricks--;
        if(numberofbricks <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level" + (currentLevelIndex + 2);    
                gameOver = true;
                Invoke("LoadLevel",3f);
            }
        }
    }

    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberofbricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
