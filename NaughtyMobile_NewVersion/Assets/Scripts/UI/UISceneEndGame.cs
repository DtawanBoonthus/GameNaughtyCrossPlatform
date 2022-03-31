using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISceneEndGame : MonoBehaviour
{
    [Header("ScriptableObject")] 
    [SerializeField] private ChooseCharacterInfo character;
    [SerializeField] private InfoUser player;
    [SerializeField] private ScoreInfo playerScoreInfo;

    [Space] 
    [Header("TMP")] 
    [SerializeField] private TextMeshProUGUI namePlayer;
    [SerializeField] private TextMeshProUGUI highestScore;
    [SerializeField] private TextMeshProUGUI score;

    [Space] 
    [Header("Image")] 
    [SerializeField] private Image jennie;
    [SerializeField] private Image john;
    
    private void Awake()
    {
        HideUI(jennie.rectTransform);
        HideUI(john.rectTransform);
        
        StartEndgame();
    }

    private void StartEndgame()
    {
        namePlayer.text = player.Name;
        highestScore.text = playerScoreInfo.MaxScore.ToString();
        score.text = playerScoreInfo.Score.ToString();
        
        SetImageCharacter();
    }
    
    private void SetImageCharacter()
    {
        if (character.Name == "Jennie")
        {
            ShowUI(jennie.rectTransform);
        }
        else if (character.Name == "John")
        {
            ShowUI(john.rectTransform);
        }
    }

    private void HideUI(RectTransform ui)
    {
        ui.gameObject.SetActive(false);
    }
    
    private void ShowUI(RectTransform ui)
    {
        ui.gameObject.SetActive(true);
    }
    
}
