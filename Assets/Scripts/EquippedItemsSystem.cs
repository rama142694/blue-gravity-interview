using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsSystem : StorageItemsSystem
{
    [SerializeField] private Item _hatUIItem;
    [SerializeField] private Item _shirtUIItem;
    [SerializeField] private Item _trousersUIItem;
    [SerializeField] private Item _shoesUIItem;

    protected override void Start()
    {
        base.Start();

        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.current.OnEquipItem += AddItem;
        EventManager.current.OnUnequipItem += RemoveItem;
    }

    public override void AddItem(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.Hat: _hatUIItem.SetItem(item, this); break;
            case ItemType.Shirt: _shirtUIItem.SetItem(item, this); break;
            case ItemType.Trousers: _trousersUIItem.SetItem(item, this); break;
            case ItemType.Shoes: _shoesUIItem.SetItem(item, this); break;
        }
    }

    public override void RemoveItem(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.Hat: _hatUIItem.RemoveItem(); break;
            case ItemType.Shirt: _shirtUIItem.RemoveItem(); break;
            case ItemType.Trousers: _trousersUIItem.RemoveItem(); break;
            case ItemType.Shoes: _shoesUIItem.RemoveItem(); break;
        }
    }

    public void UnequiItem()
    {
        EventManager.current.UnequipItem(_selectedItem);
    }
}
