using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageItemsSystem : MonoBehaviour
{
    [SerializeField] protected List<ItemSO> _startingStorageItems = new List<ItemSO>();
    [SerializeField] protected Dictionary<ItemSO, Item> _storageUIItems = new Dictionary<ItemSO, Item>();
    [SerializeField] protected Transform _storageItemsContainer;
    [SerializeField] protected Item _itemPrefab;

    [Header("Selected Item")]
    [SerializeField] protected SelectedItemInfo _selectedItemInfo;
    protected ItemSO _selectedItem;

    protected virtual void Start()
    {
        CreateStore();

        if(_selectedItemInfo)
            _selectedItemInfo.gameObject.SetActive(false);
    }

    protected void CreateStore()
    {
        foreach (var item in _startingStorageItems)
        {
            CreateNewItemUI(item);
        }
    }

    public virtual void AddItem(ItemSO item)
    {
        CreateNewItemUI(item);

        if (_selectedItem)
        {
            _storageUIItems[_selectedItem].RestoreToNormalColor();
        }
        _selectedItem = null;
        _selectedItemInfo.gameObject.SetActive(false);
    }

    public virtual void RemoveItem(ItemSO item)
    {
        if (_selectedItem)
        {
            _storageUIItems[_selectedItem].RestoreToNormalColor();
        }

        Item itemUI = _storageUIItems[item];
        _storageUIItems.Remove(item);
        Destroy(itemUI.gameObject);
        _selectedItem = null;
        _selectedItemInfo.gameObject.SetActive(false);
    }

    protected void CreateNewItemUI(ItemSO item)
    {
        Item newItem = Instantiate(_itemPrefab);
        newItem.transform.SetParent(_storageItemsContainer.transform, false);
        newItem.SetItem(item, this);
        _storageUIItems.Add(item, newItem);
    }

    public void SetSelectedItem(ItemSO item)
    {
        if(_selectedItem)
        {
            _storageUIItems[_selectedItem].RestoreToNormalColor();
        }

        _selectedItem = item;

        if (_selectedItemInfo)
        {
            _selectedItemInfo.ChangeSelectedItemInfo(item);
            _selectedItemInfo.gameObject.SetActive(true);
        }
    }
}
