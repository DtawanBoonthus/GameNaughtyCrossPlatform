using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rank;
    [SerializeField] private TextMeshProUGUI nameUser;
    [SerializeField] private TextMeshProUGUI score;
    
    public void Init(int rank, string nameUser, int score)
    {
        this.rank.text = rank.ToString();
        this.nameUser.text = nameUser;
        this.score.text = score.ToString();
    }
}
