using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.String;

public class AuthenticationManager : MonoBehaviour
{
    [SerializeField] private InfoUser infoPlayer;

    
    [SerializeField] private TMP_InputField emailInputFieldLogin;
    [SerializeField] private TMP_InputField passwordInputFieldLogin;
    [SerializeField] private Button loginButton;
    

    private void Awake()
    {
        emailInputFieldLogin.contentType = TMP_InputField.ContentType.EmailAddress;
        passwordInputFieldLogin.contentType = TMP_InputField.ContentType.Password;
        
        loginButton.onClick.AddListener(OnclickLogin);
        
        AuthHandler.SingInComplete += GetUserInfo;
    }

    private void GetUserInfo()
    {
        DatabaseHandler.GetUser(AuthHandler.userId, user =>
        {
            infoPlayer.Name = user.Name;
            infoPlayer.Score = user.Score;
            infoPlayer.UserId = AuthHandler.userId;
        }, AuthHandler.idToken);
    }
    
    private void OnclickLogin()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SingIn();
    }
    
    private void SingIn()
    {
        AuthHandler.SignIn(emailInputFieldLogin.text, passwordInputFieldLogin.text);
    }
}
