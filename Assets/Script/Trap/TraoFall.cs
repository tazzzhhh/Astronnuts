using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraoFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform refresh;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") &&!daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("Reset", 5f);
        }
    }

    private void Reset()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = refresh.position;
        daRoi = false;
    }
}
