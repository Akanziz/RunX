using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor.Search;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
       public string startSceneName = " Scene1";
       public string gameOverSceneName = "Scene3";
       public int score = 0;
       public TMP_Text scoreText;
       public static GameManager instance;

       public void StartGame()
       {
            SceneManager.LoadScene("Scene2");
       }

       public void GameOver()
       {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("Scene3");
       }

       public void RestartGame()
       {
         SceneManager.LoadScene("Scene1");
       }
       
       public void AddScore(int points)
       {
          score += points;
          UpdateScoreUI();
          PlayerPrefs.SetInt("Score", score);
       }
       void Awake()
       {
          instance = this;
       }
       void UpdateScoreUI()
       {
          if (scoreText != null)
          {
               scoreText.text = "Score: " + score;
          }
       }
    // Update is called once per frame
    void Update()
    {
        
    }
}
