using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int time;

    private void Awake()
    {
        StartGame();
    }

    private void StartGame()
    {
        UISceneGameplayManager.Instance.SetTimeText(time);
        
        StartCoroutine(CountDownTime());
    }

    private IEnumerator CountDownTime()
    {
        while (true)
        {
            if (time == 0)
            {
                EndGame();
            }
            
            yield return new WaitForSeconds(1);
            
            time -= 1;
            
            UISceneGameplayManager.Instance.SetTimeText(time);
            
        }
    }

    public void EndGame()
    {
        if (ItemManager.Instance.CountCreateItem == 0)
        {
            ScoreManager.Instance.GetScore(time);
        }

        SceneManager.LoadScene("Ads");
    }
}