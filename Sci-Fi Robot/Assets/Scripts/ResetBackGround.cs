using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBackGround : MonoBehaviour {

    public GameObject background1;
    public GameObject background;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            background.transform.localPosition = new Vector3(background.transform.localPosition.x + 76, background.transform.localPosition.y, 0);
            background1.transform.localPosition = new Vector3(background1.transform.localPosition.x + 76*2, background1.transform.localPosition.y, 0);

        }
    }
}
