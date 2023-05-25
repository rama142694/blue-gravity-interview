using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Inventory _inventory;

    [Header("Interaction")]
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactionLayerMask;

    private Rigidbody2D rb;

    void Start()
    {
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
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = movement.normalized * _speed;
    }

    private void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenOrCloseInventory(!_inventory.gameObject.activeSelf);
            _inventory.SetInventoryType(false);
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var interaction = Physics2D.OverlapCircle(transform.position, _interactionRadius, _interactionLayerMask);

            if (interaction)
            {
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
