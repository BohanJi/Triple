using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjects : MonoBehaviour
{
    public string itemName;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().AddItem(itemName);
                gameObject.SetActive(false);
            }
        }
    }
}
