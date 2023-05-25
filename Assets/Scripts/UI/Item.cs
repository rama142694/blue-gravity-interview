using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private StorageItemsSystem _itemStorage;
    private ItemSO _itemInfo;
    [SerializeField] private Image _itemImage;

    public ItemSO GetCurrentItem()
    {
        return _itemInfo;
    }

    public void SetItem(ItemSO item, StorageItemsSystem storage)
    {
        _itemInfo = item;
        _itemImage.sprite = item.itemIconSprite;
        _itemImage.gameObject.SetActive(true);
        _itemStorage = storage;
    }

    public void SetSelectedItem()
    {
        if (_itemInfo)
        {
            _itemStorage.SetSelectedItem(_itemInfo);
        }
    }

    public void RemoveItem()
    {
        _itemInfo = null;
        _itemImage.sprite = null;
        _itemImage.gameObject.SetActive(false);
    }
}
