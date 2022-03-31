using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Manager;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Manager
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        [SerializeField] private CharacterInfo player;
        [SerializeField] private ChooseCharacterInfo chooseCharacterInfo;
        [SerializeField] private CharacterInfo jennieCharacterInfo;
        [SerializeField] private CharacterInfo johnCharacterInfo;
        [SerializeField] private JennieCharacter jennieCharacter;
        [SerializeField] private JohnCharacter johnCharacter;


        [HideInInspector] public JennieCharacter Jennie;
        [HideInInspector] public JohnCharacter John;


        public void Awake()
        {
            Debug.Assert(jennieCharacterInfo != null, "jennieCharacterInfo cannot be null");
            Debug.Assert(jennieCharacter != null, "jennieCharacter cannot be null");
            Debug.Assert(johnCharacterInfo != null, "johnCharacterInfo cannot be null");
            Debug.Assert(johnCharacter != null, "johnCharacter cannot be null");

            StartGame();
        }

        private void StartGame()
        {
            if (chooseCharacterInfo.Name == "Jennie")
            {
                SpawnJennieCharacter();
            }

            if (chooseCharacterInfo.Name == "John")
            {
                SpawnJohnCharacter();
            }
        }
        
        private void SpawnJennieCharacter()
        {
            Jennie = Instantiate(jennieCharacter);
            Jennie.Init(jennieCharacterInfo.Hp, jennieCharacterInfo.Speed, jennieCharacterInfo.DefaultBullet);
            player.Hp = jennieCharacterInfo.Hp;
            player.Image = jennieCharacterInfo.Image;
            player.Name = jennieCharacterInfo.Name;
            player.Speed = jennieCharacterInfo.Speed;
            player.DefaultBullet = jennieCharacterInfo.DefaultBullet;
        }

        private void SpawnJohnCharacter()
        {
            John = Instantiate(johnCharacter);
            John.Init(johnCharacterInfo.Hp, johnCharacterInfo.Speed, johnCharacterInfo.DefaultBullet);
            player.Hp = johnCharacterInfo.Hp;
            player.Image = johnCharacterInfo.Image;
            player.Name = johnCharacterInfo.Name;
            player.Speed = johnCharacterInfo.Speed;
            player.DefaultBullet = johnCharacterInfo.DefaultBullet;
        }
    }
}