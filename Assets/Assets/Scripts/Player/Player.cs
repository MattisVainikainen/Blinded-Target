﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour, IDamageable
{
    public int diamonds; 

    Rigidbody2D _rigid;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private float _playerSpeed = 10f;
    private bool _resetJump = false;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private bool _grounded = false;
    public int Health { get; set; }
    

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    void Update()
    {
        Move();
        if(CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded()== true)
        {
            _playerAnim.Attack();
        }
        UIManager.Instance.UpdateGemCount(diamonds);
    }  

    private void Move()   
    {
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        if(move > 0)
        {
            Flip(true);

        } 
        else if (move < 0)
        {
            Flip(false);
        }

        if(CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded() == true)
        { 
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
            
        }

        _rigid.velocity = new Vector2(move * _playerSpeed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
         if (hitInfo.collider != null) 
         {
             if(_resetJump == false) 
             {
                _playerAnim.Jump(false);
                return true;
             }
             
         }

         return false;
    }

    IEnumerator ResetJumpRoutine() 
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Flip(bool facingRight)
    {
       if(facingRight == true)
       {
           transform.localScale = new Vector3(1,1,1);
          // _playerSprite.flipX = false; 
       }
       else if(facingRight == false)
       {
           transform.localScale = new Vector3(-1,1,1); 
           // _playerSprite.flipX = true;

       } 
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }
        Debug.Log("TAking damage");
        Health--;
        UIManager.Instance.UpdateLives(Health);
       if( Health <1)
       {
          _playerAnim.Death();
       }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }

    

}
