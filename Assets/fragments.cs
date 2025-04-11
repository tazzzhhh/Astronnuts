using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragments : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //tắt va chạm giữa mảnh vỡ và player
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }    
    }
}
