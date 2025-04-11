using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crushed : MonoBehaviour
{
    public float tocdotren;
    public float tocdoduoi;
    public Transform dilen;
    public Transform dixuong;
    bool dap;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= dilen.position.y)
        {
            dap = true;
        }
        if(transform.position.y <= dixuong.position.y)
        {
            dap = false;
        }
        if(dap) 
        {   
            transform.position = Vector2.MoveTowards(transform.position, dixuong.position, tocdoduoi * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, dilen.position, tocdotren * Time.deltaTime);
        }
    }
}
