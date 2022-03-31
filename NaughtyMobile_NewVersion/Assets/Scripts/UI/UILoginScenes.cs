using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoginScenes : Singleton<UILoginScenes>
{
    public RectTransform ReplyEmailNotVerified;
    public RectTransform ReplyLoginFailed;
    
    [SerializeField] private Button registerButton;
    
    private void Awake()
    {
        StartGame();
        
        registerButton.onClick.AddListener(OnClickRegister);
    }

    private void StartGame()
    {
        HideUI(ReplyEmailNotVerified);
        HideUI(ReplyLoginFailed);
    }

    public void Reply(RectTransform reply)
    {
        ShowUI(reply);
        StartCoroutine(CountDownTimeShowUI(reply));
    }
    
    private void OnClickRegister()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SceneManager.LoadScene("Register");
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
