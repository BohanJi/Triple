using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    List<string> ActivesItems = new();
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovimientoJugador();
    }

    private void MovimientoJugador() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x += 3.0f * horizontal * Time.deltaTime;
        position.y += 3.0f * vertical * Time.deltaTime;

        animator.SetFloat("Horizontal", position.x);
        animator.SetFloat("Vertical", position.y);
        animator.SetFloat("Speed", position.sqrMagnitude);

        rigidbody2d.MovePosition(position);
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
