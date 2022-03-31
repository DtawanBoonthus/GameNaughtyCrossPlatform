using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : Singleton<EndGameManager>
{
    public event Action SetScorePlayer;
    
    [SerializeField] private InfoUser player;
    [SerializeField] private ScoreInfo scorePlayer;
    
    [Space]
    [Header("Button")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        SetScore();
       
        restartButton.onClick.AddListener(OnClickRestart);
        exitButton.onClick.AddListener(OnClickExit);
    }

    private void OnClickRestart()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SceneManager.LoadScene("StartMenu");
    }
    
    private void OnClickExit()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        Application.Quit();
    }

    /*private IEnumerator Refresh()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("EndGame");
        }
    }*/
    
    private void SetScore()
    {
        DatabaseHandler.GetUser(player.UserId, user =>
        {
            DatabaseHandler.PostScore(user, player.UserId, AuthHandler.idToken, scorePlayer.MaxScore);
            
            StartCoroutine(WaitSetScore());
        }, AuthHandler.idToken);
        
    }
    
    private IEnumerator WaitSetScore()
    {
        yield return new WaitForSeconds(0.5f);
        SetScorePlayer?.Invoke();
    }
}
