using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public void Awake()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + GetHighScore();
    }
    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void IncreaseScore()
    {
        score++;
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HighScore: " + GetHighScore();
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
