using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public Action<ItemSO> OnItemBought;
    public void ItemBought(ItemSO item)
    {
        OnItemBought(item);
    }

    public Action<ItemSO> OnItemSelled;
    public void ItemSelled(ItemSO item)
    {
        OnItemSelled(item);
    }

    public Action<ItemSO> OnEquipItem;
    public void EquipItem(ItemSO item)
    {
        OnEquipItem(item);
    }

    public Action<ItemSO> OnUnequipItem;
    public void UnequipItem(ItemSO item)
    {
        OnUnequipItem(item);
    }
}
