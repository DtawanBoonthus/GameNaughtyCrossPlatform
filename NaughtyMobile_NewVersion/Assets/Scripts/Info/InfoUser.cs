using UnityEngine;

[CreateAssetMenu(fileName = "New Info", menuName = "Info User")]
public class InfoUser : ScriptableObject
{
    public string Name;
    public int Score;
    public string UserId;
}