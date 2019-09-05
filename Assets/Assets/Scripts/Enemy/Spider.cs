using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidPrefab;
    public int Health { get; set; }
    //Use for initialize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update() 
    {

    }

    public void Damage() 
    {
        Health -= 1;
        if(Health < 1 && isDead == false)
        {
            
            anim.SetTrigger("death");
            isDead = true;
            Destroy(this.gameObject, 1.5f);
        }
    }

    public override void MoveMent()
    {

    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }
}
