using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    //how fast robot can move
    public float maxSpeed = 10f;
    //robot direction
    bool facingRight = true;

    Rigidbody2D rigid;
    Animator anim;

    //not ground
    bool grounded = false;

    //tranform at robot foot to see if he is touching ground
    public Transform groundcheck;

    //how big the circle is going to be when we check distance to the ground
    float groundRadius = 0.2f;

    //force of the jump;
    public float JumpForce;

    //what layer is concidered ground
    public LayerMask whatIsGround;

    //variable check doubleJump
    bool doubleJump;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Start game set dead is false
        anim.SetBool("isDead", false);
    }

    // FixedUpdate is called once timestep
    void FixedUpdate () {

        //true or false did the ground tranform hit the whatIsGround with the groundRadius
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        //touch grounded reset doubleJump
        if (grounded)
            doubleJump = false;

        //tell the animator that we are grounded
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", rigid.velocity.y);

        //get move direction
        float move = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector3(move * maxSpeed, rigid.velocity.y, 0);

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            //not on the ground
            anim.SetBool("Ground", false);

            //add jump force to the Y asix of the rigidbody
            rigid.AddForce(new Vector2(0, JumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
