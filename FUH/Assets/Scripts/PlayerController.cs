using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    List<string> ActivesItems = new();
    float moveSpeed = 5f;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        DontDestroyOnLoad(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovimientoJugador();
    }

    void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void MovimientoJugador()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void AddItem(string ItemName)
    {
        ActivesItems.Add(ItemName);
    }
    public List<string> GetItemList()
    {
        return ActivesItems;
    }
}
