using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    //check silde
    bool sliding = false;

    //store the slide time
    float slideTime = 0f;

    //set the maximum time slide
    public float maxSlideTime = 1.5f;

    //reference to the health collider game object
    [SerializeField]
    GameObject healthCollider;

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

    public Transform muzzle;

    public GameObject bullet;

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
        GetInputMovement();
    }

    void GetInputMovement()
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

        else if ((!grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
            anim.SetBool("DoubleJumping", doubleJump);

        if(Input.GetKeyDown(KeyCode.LeftShift) && !sliding)
        {
            Time.timeScale = 0;
            slideTime = 0f;

            anim.SetBool("isSliding", true);

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            healthCollider.GetComponent<CapsuleCollider2D>().enabled = false;

            sliding = true;

        }

        if (sliding)
        {
            slideTime += Time.deltaTime;

            if (slideTime > maxSlideTime)
            {
                sliding = false;

                anim.SetBool("isSliding", false);

                gameObject.GetComponent<BoxCollider2D>().enabled = true;

                healthCollider.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject mBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            mBullet.transform.parent = GameObject.Find("GameManager").transform;

            mBullet.GetComponent<Renderer>().sortingLayerName = "Player";

            anim.SetBool("isShooting", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
            anim.SetBool("isRunShoot", false);
        }

        if (Input.GetButtonDown("Fire1") && GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            anim.SetBool("isRunShoot", true);

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
