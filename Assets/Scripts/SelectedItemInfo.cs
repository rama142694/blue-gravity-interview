using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedItemInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemPriceText;

    public void ChangeSelectedItemInfo(ItemSO item)
    {
        _itemNameText.text = item.itemName;
        _itemPriceText.text = item.itemPrice.ToString();
    }
}
