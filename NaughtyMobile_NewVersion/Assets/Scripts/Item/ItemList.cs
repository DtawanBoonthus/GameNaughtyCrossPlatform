using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public Image ImageItem;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;
    
    public void Init(Enum nameItem, Sprite imageItem, int count)
    {
        Name.text = nameItem.ToString();
        ImageItem.sprite = imageItem;
        Count.text = count.ToString();
    }
}
