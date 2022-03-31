using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UISceneGameplayManager : Singleton<UISceneGameplayManager>
    {
        [SerializeField] private CharacterInfo player;
        
        #region Set UI

        #region UI Utilities

        [SerializeField] private HpUI hpUi;
        [SerializeField] private Transform hpPanel;
        [SerializeField] private Sprite imageHp;
        [SerializeField] private RectTransform openUI;
        [SerializeField] private RectTransform shelfPanel;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI countBulletText;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        #endregion
        
        #region UI Shelf

        [Header("Shelf UI")] [SerializeField] private RectTransform shelfZero;
        [SerializeField] private RectTransform shelfOne;
        [SerializeField] private RectTransform shelfTwo;
        [SerializeField] private RectTransform shelfThree;
        [SerializeField] private RectTransform shelfFour;
        [SerializeField] private RectTransform shelfFive;
        [SerializeField] private RectTransform shelfSix;
        [SerializeField] private RectTransform shelfSeven;
        [SerializeField] private RectTransform shelfEight;
        [SerializeField] private RectTransform shelfNine;
        [SerializeField] private RectTransform shelfTen;
        [SerializeField] private RectTransform shelfEleven;
        [SerializeField] private RectTransform shelfTwelve;
        [SerializeField] private RectTransform shelfThirteen;
        [SerializeField] private RectTransform shelfFourteen;
        [SerializeField] private RectTransform shelfFifteen;
        [SerializeField] private RectTransform shelfSixteen;

        #endregion

        #endregion

        private List<HpUI> hpUis = new List<HpUI>();

       
        private void Awake()
        {
            StartGame();
        }
        

        private void StartGame()
        {
            CloseShelfUI();
            CloseShelfPanel();
            CloseOpenUI();
            StartHpUI();
        }

        private void StartHpUI()
        {
            for (int i = 0; i < player.Hp; i++)
            {
                var hpUI = Instantiate(hpUi, hpPanel);
                hpUI.Init(imageHp);
                
                hpUis.Add(hpUI);
            }
        }

        public void SetHpUI(int damage)
        {
            hpUis[player.Hp - damage].gameObject.SetActive(false);
        }
        
        public void SetTimeText(int time)
        {
            timeText.text = time.ToString();
        }
        
        public void SetScoreText(int score)
        {
            scoreText.text = score.ToString();
        }

        public void SetCountBulletText(int countBullet)
        {
            countBulletText.text = countBullet.ToString();
        }
        
        #region Show Shelf UI
        
        public void ShowShelfZero()
        {
            ShowUI(shelfZero);
        }
        
        public void ShowShelfOne()
        {
            ShowUI(shelfOne);
        }
        
        public void ShowShelfTwo()
        {
            ShowUI(shelfTwo);
        }
        
        public void ShowShelfThree()
        {
            ShowUI(shelfThree);
        }
        
        public void ShowShelfFour()
        {
            ShowUI(shelfFour);
        }
        
        public void ShowShelfFive()
        {
            ShowUI(shelfFive);
        }
        
        public void ShowShelfSix()
        {
            ShowUI(shelfSix);
        }
        
        public void ShowShelfSeven()
        {
            ShowUI(shelfSeven);
        }
        
        public void ShowShelfEight()
        {
            ShowUI(shelfEight);
        }
        
        public void ShowShelfNine()
        {
            ShowUI(shelfNine);
        }
        
        public void ShowShelfTen()
        {
            ShowUI(shelfTen);
        }
        
        public void ShowShelfEleven()
        {
            ShowUI(shelfEleven);
        }
        
        public void ShowShelfTwelve()
        {
            ShowUI(shelfTwelve);
        }
        
        public void ShowShelfThirteen()
        {
            ShowUI(shelfThirteen);
        }
        
        public void ShowShelfFourteen()
        {
            ShowUI(shelfFourteen);
        }
        
        public void ShowShelfFifteen()
        {
            ShowUI(shelfFifteen);
        }
        
        public void ShowShelfSixteen()
        {
            ShowUI(shelfSixteen);
        }

        #endregion
        
        public void ShowShelfPanel()
        {
            ShowUI(shelfPanel);
        }
        
        public void CloseShelfPanel()
        {
            HideUI(shelfPanel);
        }
        
        public void CloseOpenUI()
        {
            HideUI(openUI);
        }

        public void ShowOpenUI()
        {
            ShowUI(openUI);
        }
        
        public void CloseShelfUI()
        {
            HideUI(shelfZero);
            HideUI(shelfOne);
            HideUI(shelfTwo);
            HideUI(shelfThree);
            HideUI(shelfFour);
            HideUI(shelfFive);
            HideUI(shelfSix);
            HideUI(shelfSeven);
            HideUI(shelfEight);
            HideUI(shelfNine);
            HideUI(shelfTen);
            HideUI(shelfEleven);
            HideUI(shelfTwelve);
            HideUI(shelfThirteen);
            HideUI(shelfFourteen);
            HideUI(shelfFifteen);
            HideUI(shelfSixteen);
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
}