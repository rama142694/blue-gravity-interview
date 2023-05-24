using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Store _itemStore;
    private ItemSO _itemInfo;
    [SerializeField] private Image _itemImage;

    public void SetItem(ItemSO item, Store store)
    {
        _itemInfo = item;
        _itemImage.sprite = item.itemSprite;
        _itemStore = store;
    }

    public void SetSelectedItem()
    {
        _itemStore.SetSelectedItem(_itemInfo);
    }
}
