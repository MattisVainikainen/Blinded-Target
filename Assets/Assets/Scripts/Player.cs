using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigid;

    [SerializeField]
    private float jumpForce = 5.0f;

    [SerializeField]
    private bool isGrounded = false;

    private bool resetJump = false;



    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        Move();
        Jump();
    } 

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            isGrounded = false;
            resetJump = true;
            StartCoroutine(ResetJumpTime()); 
        }

       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
       Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

       if(hitInfo.collider != null) 
       {
           if(resetJump == false)
            {
                isGrounded = true;
            }
           
       }
    }

    IEnumerator ResetJumpTime()
    {
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
    }
}
