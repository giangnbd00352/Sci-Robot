using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public float health = 100f;

    public Transform target;

    public float engaugeDistance = 10f;

    public float attackDistance = 3f;

    public float moveSpeed = 5f;

    private bool facingLeft = true;

    private Animator anim;

    private Rigidbody2D rigid;

    public RobotController robotController;

    public float attackDamage = 2f;

    public SpriteRenderer healthBar;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("isIdle", true);
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", false);

        if (Vector3.Distance(target.position, this.transform.position) < engaugeDistance)
        {
            anim.SetBool("isIdle", false);
            //get the direction of the target
            Vector3 direction = target.position - this.transform.position;

            if (Mathf.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }


            if (direction.magnitude >= attackDistance)
            {
                anim.SetBool("isWalk", true);
                Debug.DrawLine(target.position, this.transform.position, Color.yellow);

                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }
            }


            if (direction.magnitude < attackDistance)
            {
                Debug.DrawLine(target.position, this.transform.position, Color.red);
                anim.SetBool("isAttack", true);
                if (robotController.GetComponentInChildren<PlayerHealth>().currentHealth > 0)
                {
                    robotController.GetComponentInChildren<PlayerHealth>().currentHealth -= attackDamage;
                }
               
            }

        } 
        else if (Vector3.Distance(target.position, this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(target.position, this.transform.position, Color.green);
        }
	}

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
            healthBar.GetComponent<Transform>().localScale -= new Vector3(.1f, 0, 0);

            if (health <= 0)
            {
                anim.SetBool("isDead", true);
                Destroy(gameObject, 2);
            }            
        }
    }
}
