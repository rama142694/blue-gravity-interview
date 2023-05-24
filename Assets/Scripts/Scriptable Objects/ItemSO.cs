using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "new Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public float itemPrice;
    public Sprite itemSprite;
    public ItemType itemType;
}
