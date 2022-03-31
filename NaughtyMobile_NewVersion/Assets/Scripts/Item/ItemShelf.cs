using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShelf : MonoBehaviour
{
    public Image ImageItem;
    public TextMeshProUGUI Name;
    public Button Button;

    public void Init(Enum nameItem, Sprite imageItem)
    {
        Name.text = nameItem.ToString();
        ImageItem.sprite = imageItem;
    }
}
