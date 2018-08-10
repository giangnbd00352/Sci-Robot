using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    Vector3 firstPosition;
    Vector3 getPosition;
    bool positionRobot = false;
    float speed;
    public GameObject robot;
	// Use this for initialization
	void Start () {
        firstPosition = transform.localPosition;
        speed = 3f;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(speed * Time.deltaTime, 0 , 0));

        getPosition = transform.localPosition;

        if (Vector3.Distance(firstPosition, getPosition) > 8)
        {
            firstPosition = getPosition;
            speed = -speed;
            transform.Translate(new Vector3( speed * Time.deltaTime, 0, 0));
        }

        if (positionRobot)
        {
            robot.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            positionRobot = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {     
        if (collision.gameObject.tag == "Player")
        {
            positionRobot = false;
        }
    }

}
