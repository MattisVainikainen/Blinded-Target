﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool _canDamage = true;

    void OnTriggerEnter2D(Collider2D other) 
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if(hit != null)
        {       
            if(_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
                
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
