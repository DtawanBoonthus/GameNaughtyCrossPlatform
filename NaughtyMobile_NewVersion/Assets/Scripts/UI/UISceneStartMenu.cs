using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISceneStartMenu : MonoBehaviour
{

    [SerializeField] private ChooseCharacterInfo chooseCharacterInfo;
    [SerializeField] private RectTransform menuUI;
    [SerializeField] private RectTransform chooseCharacterUI;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button jennieCharacterButton;
    [SerializeField] private Button johnCharacterButton;

    private void Awake()
    {
        HideUI(chooseCharacterUI);
        HideButton(backButton);
        
        playButton.onClick.AddListener(OnClickPlayButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        backButton.onClick.AddListener(OnClickBackButton);
        jennieCharacterButton.onClick.AddListener(OnClickJennieCharacterButton);
        johnCharacterButton.onClick.AddListener(OnClickJohnCharacterButton);
    }
    
    private void OnClickPlayButton()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        ShowUI(chooseCharacterUI);
        HideUI(menuUI);
        ShowButton(backButton);
    }

    private void OnClickBackButton()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        ShowUI(menuUI);
        HideUI(chooseCharacterUI);
        HideButton(backButton);
    }
    
    private void OnClickExitButton()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        Application.Quit();
    }
    
    private void OnClickJennieCharacterButton()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        chooseCharacterInfo.Name = "Jennie";
        LoadSceneGamePlay();
    }

    private void OnClickJohnCharacterButton()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        chooseCharacterInfo.Name = "John";
        LoadSceneGamePlay();
    }
    
    private void LoadSceneGamePlay()
    {
        SceneManager.LoadSceneAsync("GamePlay");
    }
    
    private void ShowUI(RectTransform ui)
    {
        ui.gameObject.SetActive(true);
    }

    private void HideUI(RectTransform ui)
    {
        ui.gameObject.SetActive(false);
    }

    private void ShowButton(Button button)
    {
        button.gameObject.SetActive(true);
    }

    private void HideButton(Button button)
    {
        button.gameObject.SetActive(false);
    }
}
