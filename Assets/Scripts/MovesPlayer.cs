using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesPlayer : MonoBehaviour
{
    public int runspeed = 1;
    private Rigidbody2D rb;


    float horizontal;
    float vertical;
    Animator animator;
    bool facingRight;

    //Attack
    //  bool isAttacking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));
    }

    void FixedUpdate()
    {

    Vector3 movement = new Vector3(horizontal * runspeed, vertical * runspeed, 0.0f);
    transform.position = transform.position + movement * Time.deltaTime;
    Flip(horizontal);

        //if(Input.GetButton("Fire1"))
        //{
           // isAttacking = true; 
          //  if(vertical != 0 || horizontal != 0)
           // {
          //      vertical = 0;
          //      horizontal = 0;
          //      animator.SetFloat("Speed", 0);
           // }

           // animator.SetTrigger("Punch");
      //  }
    }

  //  public void AlertObservers(string message)
  //  {
  //      if (message == "AttackEnded")
  //          isAttacking = false;
  //  }

    private void Flip(float horizontal)
    {
        if(horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }


    }
}
