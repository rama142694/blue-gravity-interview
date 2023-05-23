using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public float itemPrice;
    public Image itemIcon;
}
