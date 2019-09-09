using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
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
        if(direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = false;
            // transform.localScale = new Vector3(3, 3, 3);
        }
        else if (direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = true;
           // transform.localScale = new Vector3(-3, 3, 3);
        }
    }

    public void Damage()
    {
        if (isDead == false)
        {
            Health -= 1;
            anim.SetTrigger("hit");
            isHit = true;
            anim.SetBool("inCombat", true);

            if(Health < 1)
            {
            isDead = true;
            anim.SetTrigger("death");
                GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = base.gems;   
            }
        }
    }

    
}
