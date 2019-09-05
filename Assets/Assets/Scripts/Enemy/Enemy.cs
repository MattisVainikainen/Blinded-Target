using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isHit = false;

    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    private void Start() 
    {
        Init(); 
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && anim.GetBool("inCombat") == false)
        {
            return;
        }
        MoveMent();
    }

    public virtual void MoveMent()
    {
            if (currentTarget == pointA.position)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            if (transform.position == pointA.position)
            {
                currentTarget = pointB.position;
                anim.SetTrigger("idle");
            }
            else if (transform.position == pointB.position)
            {
                currentTarget = pointA.position;
                anim.SetTrigger("idle");
            }

            if(isHit == false)
            {
            transform.localPosition = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            
            }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if(distance > 2.0f)  
        {
            isHit = false;
            anim.SetBool("inCombat", false);
        }  
    }  
}
