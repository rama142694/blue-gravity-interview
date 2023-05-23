using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractuable
{
    [SerializeField] private Store _store;

    private void Start()
    {
        _store.gameObject.SetActive(false);
    }

    public void Interact()
    {
        _store.gameObject.SetActive(!_store.gameObject.activeSelf);
    }
}
