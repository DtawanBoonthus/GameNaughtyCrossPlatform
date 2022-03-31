using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRegisterScenes : Singleton<UIRegisterScenes>
{
    public RectTransform ReplyRegisterFailed;
    public RectTransform ReplyRegisterComplete;
    
    [SerializeField] private Button backButton;

    private void Awake()
    {
        StartGame();
        
        backButton.onClick.AddListener(OnClickBack);
    }
    
    private void StartGame()
    {
        HideUI(ReplyRegisterComplete);
        HideUI(ReplyRegisterFailed);
    }
    
    private void OnClickBack()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SceneManager.LoadScene("Login");
    }
    
    public void Reply(RectTransform reply)
    {
        ShowUI(reply);
        StartCoroutine(CountDownTimeShowUI(reply));
    }
    
    private void ShowUI(RectTransform ui)
    {
        ui.gameObject.SetActive(true);
    }

    private void HideUI(RectTransform ui)
    {
        ui.gameObject.SetActive(false);
    }

    private IEnumerator CountDownTimeShowUI(RectTransform ui)
    {
        yield return new WaitForSeconds(1);
        
        HideUI(ui);
    }
}
