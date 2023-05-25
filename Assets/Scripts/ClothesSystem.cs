using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _hatSprite;
    [SerializeField] private SpriteRenderer _shirtSprite;
    [SerializeField] private SpriteRenderer _trouserSprite;
    [SerializeField] private SpriteRenderer _shoeSprite;

    private void Start()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.current.OnEquipItem += EquipItem;
        EventManager.current.OnUnequipItem += UnequipItem;
    }

    private void UnsubscribeEvents()
    {
        EventManager.current.OnEquipItem -= EquipItem;
        EventManager.current.OnUnequipItem -= UnequipItem;
    }

    private void EquipItem(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.Hat: _hatSprite.sprite = item.itemEquippedSprite; break;
            case ItemType.Shirt: _shirtSprite.sprite = item.itemEquippedSprite; break;
            case ItemType.Trousers: _trouserSprite.sprite = item.itemEquippedSprite; break;
            case ItemType.Shoes: _shoeSprite.sprite = item.itemEquippedSprite; break;
        }
    }

    private void UnequipItem(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.Hat: _hatSprite.sprite = null; break;
            case ItemType.Shirt: _shirtSprite.sprite = null; break;
            case ItemType.Trousers: _trouserSprite.sprite = null; break;
            case ItemType.Shoes: _shoeSprite.sprite = null; break;
        }
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
