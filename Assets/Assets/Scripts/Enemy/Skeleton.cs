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

    
    public void Damage() 
    {
       Health -= 1;
       anim.SetTrigger("hit");
       isHit = true;
       anim.SetBool("inCombat", true);

       if(Health < 1)
       {
           anim.SetTrigger("death");
            StartCoroutine(DeathTime());
       }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(this.gameObject);
    }
}
