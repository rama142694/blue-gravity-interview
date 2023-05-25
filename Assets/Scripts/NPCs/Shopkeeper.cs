using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractuable
{
    [SerializeField] private Store _store;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _interactionPopUp;

    private void Start()
    {
        _store.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) <= 3)
        {
            _interactionPopUp.gameObject.SetActive(true);
        }
        else
        {
            _interactionPopUp.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        _store.gameObject.SetActive(!_store.gameObject.activeSelf);
    }
}
