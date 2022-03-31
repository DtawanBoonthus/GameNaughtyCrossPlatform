using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private ScoreInfo playerScore;

    private void Awake()
    {
        StartGame();
    }

    private void StartGame()
    {
        playerScore.Score = 0;
        GetMaxScore();
        UISceneGameplayManager.Instance.SetScoreText(playerScore.Score);
    }
    
    private void GetMaxScore()
    {
        DatabaseHandler.GetUser(AuthHandler.userId, user =>
        {
            playerScore.MaxScore = user.Score;
        }, AuthHandler.idToken);
    }
    
    private void Update()
    {
        SetMaxScore(playerScore.Score);
    }

    public void GetScore(int score)
    {
        SetScore(score);
    }

    private void SetScore(int score)
    {
        playerScore.Score += score;
        UISceneGameplayManager.Instance.SetScoreText(playerScore.Score);
    }

    private void SetMaxScore(int score)
    {
        if (score > playerScore.MaxScore)
        {
            playerScore.MaxScore = score;
        }
    }
}
