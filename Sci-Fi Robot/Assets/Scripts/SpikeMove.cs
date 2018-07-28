using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour {

    float Speed;

    Vector3 firstPosition;
    bool facingUp;
    // Use this for initialization
    void Start () {
        Speed = 5f;
        firstPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));

        Vector3 getCurrentPosition = transform.localPosition;

        if (Vector3.Distance(firstPosition, getCurrentPosition) > 8)
        {
            if (Speed > 0 && !facingUp)
                Flip();
            if (Speed < 0 && facingUp)
                Flip();
            firstPosition = getCurrentPosition;
            Speed = -Speed;
            transform.Translate(new Vector3(0,Speed * Time.deltaTime, 0));
        }
	}

    void Flip()
    {
        facingUp = !facingUp;
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
}
