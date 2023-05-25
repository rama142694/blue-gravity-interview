using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    [Header("General Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private Inventory _inventory;
    private bool _canMove;
    private bool _isInventoryOpen;
    private bool _isStoreOpen;

    [Header("Interaction")]
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactionLayerMask;


    [Header("Components")]
    private Rigidbody2D rb;

    void Start()
    {
        _canMove = true;
        rb = GetComponent<Rigidbody2D>();
        OpenOrCloseInventory(false);
    }

    void Update()
    {
        Move();
        Interact();
        Inventory();
    }

    private void Move()
    {
        if (!_canMove) { rb.velocity = Vector3.zero; return; }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = movement.normalized * _speed;
    }

    private void Inventory()
    {
        if (_isStoreOpen) return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            _canMove = !_canMove;
            _isInventoryOpen = !_isInventoryOpen;
            OpenOrCloseInventory(!_inventory.gameObject.activeSelf);
            _inventory.SetInventoryType(false);
        }
    }

    private void Interact()
    {
        if (_isInventoryOpen) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            var interaction = Physics2D.OverlapCircle(transform.position, _interactionRadius, _interactionLayerMask);

            if (interaction)
            {
                _canMove = !_canMove;
                _isStoreOpen = !_isStoreOpen;
                interaction.GetComponent<IInteractuable>().Interact();
                OpenOrCloseInventory(!_inventory.gameObject.activeSelf);
                _inventory.SetInventoryType(true);
            }
        }
    }

    private void OpenOrCloseInventory(bool closeOrOpen)
    {
        _inventory.gameObject.SetActive(closeOrOpen);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _interactionRadius);
    }
}
