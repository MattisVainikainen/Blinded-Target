using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;

    private void Start() 
    {
       _anim = GetComponentInChildren<Animator>();
    }


    public override void Update()
    {
       if(_anim.GetCurrentAnimatorStateInfo(0).IsName("idle")) 
       {
           return;
       }
       Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("idle"); 
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}
