using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool Attack;
    private Rigidbody2D PlayerRigidBody;
    private bool facingRight;
    private Animator myAnimator;
    [SerializeField]
    private float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
       
        
    }
    private void Update()
    {
        HandleInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        ResetValues();
    }
    private void HandleMovement(float horizontal)
    {
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
        {
            PlayerRigidBody.velocity = new Vector2(horizontal*MoveSpeed, PlayerRigidBody.velocity.y);
        }
    
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void HandleAttacks() 
    {
        if (Attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
        {
            myAnimator.SetTrigger("Attack");
            PlayerRigidBody.velocity = Vector2.zero;
        }
    }
    private void HandleInput() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Attack = true;
        }
    }

    private void Flip(float movement) 
    {
        if (movement > 0 && !facingRight || movement < 0 && facingRight) 
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValues() 
    {
        Attack = false;
    }
}
