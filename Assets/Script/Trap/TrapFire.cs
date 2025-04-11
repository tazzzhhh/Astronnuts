using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFire : PlayerLife
{
    private Animator anim;


    private bool SwitchFire;
    [SerializeField] private float xuong;
    private float tgianxuong;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(SwitchFire)
            base.OnCollisionEnter2D(collision);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        tgianxuong -= Time.deltaTime;

        if(tgianxuong < 0)
        {
            SwitchFire = !SwitchFire;
            tgianxuong = xuong;
        }

        anim.SetBool("SwitchFire", SwitchFire);
    }

}
