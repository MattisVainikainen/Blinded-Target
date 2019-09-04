﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    //Use for initialize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void MoveMent()
    {
        base.MoveMent();
        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
    }

    public void Damage()
    {
        Health -= 1;
        anim.SetTrigger("hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        if (Health < 1)
        {
            anim.SetTrigger("death");
            StartCoroutine(DeathTime());
        }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
