using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private float _currentCoins;
    [SerializeField] private TMP_Text _currentCoinsText;

    private void Start()
    {
        SubscribeEvents();
        _currentCoinsText.text = _currentCoins.ToString();
    }

    private void SubscribeEvents()
    {
        EventManager.current.OnItemBought += RemoveCoins;
        EventManager.current.OnItemSelled += AddCoins;
    }

    private void UnsubscribeEvents()
    {
        EventManager.current.OnItemBought -= RemoveCoins;
        EventManager.current.OnItemSelled -= AddCoins;
    }

    private void AddCoins(ItemSO item)
    {
        _currentCoins += item.itemPrice;
        _currentCoinsText.text = _currentCoins.ToString();
    }

    private void RemoveCoins(ItemSO item)
    {
        _currentCoins -= item.itemPrice;
        _currentCoinsText.text = _currentCoins.ToString();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
