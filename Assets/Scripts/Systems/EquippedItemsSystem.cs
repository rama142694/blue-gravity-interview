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

    private void UnsubscribeEvents()
    {
        EventManager.current.OnEquipItem -= AddItem;
        EventManager.current.OnUnequipItem -= RemoveItem;
    }

    public override void AddItem(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.Hat: EquipItem(_hatUIItem, item); break;
            case ItemType.Shirt: EquipItem(_shirtUIItem, item); break;
            case ItemType.Trousers: EquipItem(_trousersUIItem, item); break;
            case ItemType.Shoes: EquipItem(_shoesUIItem, item); break;
        }

        _selectedItem = null;
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

        _selectedItem = null;
    }

    private void EquipItem(Item itemUI, ItemSO itemToEquip)
    {
        if(_selectedItem)
        {
            _storageUIItems[_selectedItem].RestoreToNormalColor();
        }

        ItemSO currentItem = itemUI.GetCurrentItem();

        if (currentItem)
        {
            _storageUIItems[currentItem].RestoreToNormalColor();
            _storageUIItems.Remove(currentItem);
            EventManager.current.AddItemToInventory(currentItem);
        }

        _storageUIItems.Add(itemToEquip, itemUI);
        itemUI.SetItem(itemToEquip, this);
    }

    public void UnequipItem()
    {
        if (_selectedItem)
        {
            _storageUIItems[_selectedItem].RestoreToNormalColor();
            _storageUIItems.Remove(_selectedItem);
            EventManager.current.UnequipItem(_selectedItem);
        }
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
