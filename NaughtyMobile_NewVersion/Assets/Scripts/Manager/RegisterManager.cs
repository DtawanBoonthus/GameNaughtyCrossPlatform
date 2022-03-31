using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    private List<string> nameUsers = new List<string>();
    
    [SerializeField] private TMP_InputField nameInputFieldRegister;
    [SerializeField] private TMP_InputField emailInputFieldRegister;
    [SerializeField] private TMP_InputField passwordInputFieldRegister;
    [SerializeField] private Button registerButton;
    
    private void Awake()
    {
        registerButton.onClick.AddListener(OnclickRegister);
        
        GetNameUsers();
    }
    
    private void OnclickRegister()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SingUp();
    }
    
    private void SingUp()
    {
        if (nameInputFieldRegister.text == "" || emailInputFieldRegister.text == "")
        {
            UIRegisterScenes.Instance.Reply(UIRegisterScenes.Instance.ReplyRegisterFailed);
            return;
        }
        
        foreach (var nameUser in nameUsers)
        {
            if (String.Equals(nameUser, nameInputFieldRegister.text, StringComparison.CurrentCultureIgnoreCase))
            {
                UIRegisterScenes.Instance.Reply(UIRegisterScenes.Instance.ReplyRegisterFailed);
                return;
            }
        }
        
        AuthHandler.SignUp(emailInputFieldRegister.text, passwordInputFieldRegister.text, new User(nameInputFieldRegister.text));

        StartCoroutine(LoadLoginScene());
    }
    
    private void GetNameUsers()
    {
        DatabaseHandler.GetUsers(users =>
        {
            foreach (var user in users)
            {
                nameUsers.Add(user.Value.Name);
            }
        });
    }

    private IEnumerator LoadLoginScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Login");
    }
}
