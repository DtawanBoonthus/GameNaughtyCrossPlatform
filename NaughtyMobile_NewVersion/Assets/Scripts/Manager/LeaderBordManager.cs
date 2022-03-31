using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBordManager : MonoBehaviour
{
    [SerializeField] private RankInfo rankInfo;
    [SerializeField] private Transform panel;

    private List<User> rankUsers = new List<User>();
    
    private void Awake()
    {
        EndGameManager.Instance.SetScorePlayer += GetInfoUsers;
    }
    
    private void GetInfoUsers()
    {
        DatabaseHandler.GetUsers(users =>
        {
            foreach (var user in users)
            {
                rankUsers.Add(new User(user.Value.Name, user.Value.Score));
            }
            
            SetRank();
        });
    }

    private void SetRank()
    {
        for (int i = 0; i < rankUsers.Count; i++)
        {
            for (int j = 0; j < rankUsers.Count; j++)
            {
                if (rankUsers[j].Score < rankUsers[i].Score)
                {
                    var tmp = rankUsers[i].Score;
                    var nameTmp = rankUsers[i].Name;
                    
                    rankUsers[i].Score = rankUsers[j].Score;
                    rankUsers[i].Name = rankUsers[j].Name;
                    
                    rankUsers[j].Score = tmp;
                    rankUsers[j].Name = nameTmp;
                }
            }
        }

        for (int i = 0; i < rankUsers.Count; i++)
        {
            var item = Instantiate(rankInfo, panel);
            item.Init(i + 1, rankUsers[i].Name, rankUsers[i].Score);
        }
    }
}
