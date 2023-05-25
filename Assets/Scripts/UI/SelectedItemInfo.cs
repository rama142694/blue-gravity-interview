using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedItemInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemTypeText;
    [SerializeField] private TMP_Text _itemPriceText;
    [SerializeField] private GameObject _itemPriceContainer;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _equipButton;

    public void ChangeSelectedItemInfo(ItemSO item)
    {
        _itemNameText.text = item.itemName;
        _itemTypeText.text = item.itemType.ToString();
        _itemPriceText.text = item.itemPrice.ToString();
    }

    public void SetSelectedItemInfoUI(bool isShop)
    {
        if (isShop)
        {
            _buyButton.gameObject.SetActive(true);
            _equipButton.gameObject.SetActive(false);
            _itemPriceContainer.SetActive(true);
        }
        else
        {
            _buyButton.gameObject.SetActive(false);
            _equipButton.gameObject.SetActive(true);
            _itemPriceContainer.SetActive(false);
        }
    }
}
