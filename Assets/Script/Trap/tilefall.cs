using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilefall : MonoBehaviour
{

    public float tgianrot;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        { 
            Destroy(gameObject, tgianrot);
        }
    }
}
