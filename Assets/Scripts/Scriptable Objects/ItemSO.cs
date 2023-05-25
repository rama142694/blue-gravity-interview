using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "new Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public float itemPrice;
    public Sprite itemIconSprite;
    public Sprite itemEquippedSprite;
    public ItemType itemType;
}
