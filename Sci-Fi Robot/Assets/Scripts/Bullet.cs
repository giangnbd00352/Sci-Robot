using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;

    RobotController robot;


	// Use this for initialization
	void Start () {
        robot = FindObjectOfType<RobotController>();

        if (robot.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);

        Destroy(gameObject, 2f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
