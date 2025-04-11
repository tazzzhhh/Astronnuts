using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHeadRock : MonoBehaviour
{
    public float tocdotrai;
    public float tocdophai;
    public Transform trai;
    public Transform phai;
    bool dap;


    // Update di chuyển của trap rockhead
    void Update()
    {
        if (transform.position.x >= trai.position.x)
        {
            dap = false;
        }
        if (transform.position.x <= phai.position.x)
        {
            dap = true;
        }
        if (dap)
        {
            transform.position = Vector2.MoveTowards(transform.position, trai.position, tocdotrai * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, phai.position, tocdophai * Time.deltaTime);
        }
    }
}
