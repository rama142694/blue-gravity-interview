using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : StorageItemsSystem
{
    protected override void Start()
    {
        base.Start();

        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        EventManager.current.OnItemSelled += RemoveItem;
        EventManager.current.OnItemBought += AddItem;
    }

    public void SellItem()
    {
        EventManager.current.ItemSelled(_selectedItem);
    }
}
