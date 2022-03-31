using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName = "Score")]
public class ScoreInfo : ScriptableObject
{
   public int Score;
   public int MaxScore;
}
