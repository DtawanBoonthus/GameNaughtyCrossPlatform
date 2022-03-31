using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterInfo : ScriptableObject
{
    public string Name;
    public int Hp;
    public float Speed;
    public Bullet DefaultBullet;
    public Sprite Image;
}
