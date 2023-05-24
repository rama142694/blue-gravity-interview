using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : StorageItemsSystem
{
    [SerializeField] private EquippedItemsSystem _equippedItems;

    protected override void Start()
    {
        base.Start();

        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        EventManager.current.OnItemSelled += RemoveItem;
        EventManager.current.OnItemBought += AddItem;
        EventManager.current.OnEquipItem += RemoveItem;
        EventManager.current.OnUnequipItem += AddItem;
    }

    public void SellItem()
    {
        EventManager.current.ItemSelled(_selectedItem);
    }

    public void EquipItem()
    {
        EventManager.current.EquipItem(_selectedItem);
    }

    public void SetInventoryType(bool isShop)
    {
        _selectedItemInfo.SetSelectedItemInfoUI(isShop);
        _equippedItems.gameObject.SetActive(!isShop);
    }
}
