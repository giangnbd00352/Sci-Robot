using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour {

    public Transform target;

    public float engaugeDistance = 10f;

    public float attackDistance = 3f;

    public float FireDistance = 4f;

    public float moveSpeed = 5f;

    private bool facingLeft = true;

    private Animator anim;

    public RobotController robotController;

    public float attackDamage = .2f;

    public Slider healthBar;

    public Text healthText;

    public GameObject bullet;

    public Transform muzzle;

    float StartTime;
    float GetTime;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        StartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isFly", false);

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
                anim.SetBool("isAttack", true);
                Debug.DrawLine(target.position, this.transform.position, Color.yellow);
                if (facingLeft)
                {
                    attackBullet(1);                    
                }
                else if (!facingLeft)
                {
                    attackBullet(-1);
                }

            }

            //if (direction.magnitude >= attackDistance)
            //{
            //    anim.SetBool("isWalk", true);
            //    Debug.DrawLine(target.position, this.transform.position, Color.green);
            //    if (facingLeft)
            //    {
            //        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
            //        healthText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            //    }
            //    else if (!facingLeft)
            //    {
            //        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //        healthText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 180, 0);
            //    }

            //}


            if (direction.magnitude < attackDistance)
            {
                Debug.DrawLine(target.position, this.transform.position, Color.red);
                anim.SetBool("isFly", true);
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

    public void addDamage(float damage)
    {
        healthBar.value -= damage;
        healthText.text = healthBar.value.ToString() + "%";
        if (healthBar.value <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }
    }

    void attackBullet(int direction)
    {
        GetTime = Time.time;
        if (GetTime - StartTime > 1.5f)
        {
            GameObject NewRG;
            NewRG = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
            NewRG.SetActive(true);
            NewRG.GetComponent<Rigidbody2D>().velocity = new Vector2(-15f * direction, GetComponent<Rigidbody2D>().velocity.y);
            NewRG.GetComponent<Transform>().localScale *= direction;
            StartTime = Time.time;
            Destroy(NewRG, 2f);
        }
    }
}
