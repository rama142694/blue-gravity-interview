using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : StorageItemsSystem
{
    protected override void Start()
    {
        base.Start();

        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        EventManager.current.OnItemSelled += AddItem;
        EventManager.current.OnItemBought += RemoveItem;
    }

    public void BuyItem()
    {
        EventManager.current.ItemBought(_selectedItem);
    }
}
