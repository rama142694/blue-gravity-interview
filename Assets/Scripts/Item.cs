using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private StorageItemsSystem _itemStorage;
    private ItemSO _itemInfo;
    [SerializeField] private Image _itemImage;

    public void SetItem(ItemSO item, StorageItemsSystem storage)
    {
        _itemInfo = item;
        _itemImage.sprite = item.itemSprite;
        _itemStorage = storage;
    }

    public void SetSelectedItem()
    {
        _itemStorage.SetSelectedItem(_itemInfo);
    }
}
