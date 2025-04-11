using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolite : MonoBehaviour
{
    public float jumpForce = 20f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}   
