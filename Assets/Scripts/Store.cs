using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private List<ItemSO> _startingStoreItems = new List<ItemSO>();
    [SerializeField] private Dictionary<ItemSO, Item> _storeUIItems = new Dictionary<ItemSO, Item>();
    [SerializeField] private Transform _storeItemsContainer;
    [SerializeField] private Item _itemPrefab;

    [Header("Selected Item")]
    [SerializeField] private ItemSO _selectedItem;

    private void Start()
    {
        CreateStore();    
    }

    private void CreateStore()
    {
        foreach (var item in _startingStoreItems)
        {
            CreateNewItemUI(item);
        }
    }

    public void BuyItem()
    {
        _storeUIItems.Remove(_selectedItem);
    }

    public void SellItem()
    {
        CreateNewItemUI(_selectedItem);
    }

    private void CreateNewItemUI(ItemSO item)
    {
        Item newItem = Instantiate(_itemPrefab);
        newItem.transform.SetParent(_storeItemsContainer.transform, false);
        newItem.SetItem(item, this);
        _storeUIItems.Add(item, newItem);
    }

    public void SetSelectedItem(ItemSO item)
    {
        _selectedItem = item;
    }
}
