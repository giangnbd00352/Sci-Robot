using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float speed = 15f;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        Destroy(gameObject, 1f);
    }
}
