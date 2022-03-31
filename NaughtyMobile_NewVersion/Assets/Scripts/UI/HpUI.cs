using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpUI : MonoBehaviour
{
    public Image ImageHp;
    
    public void Init(Sprite imageHp)
    { 
        ImageHp.sprite = imageHp;
    }
}
