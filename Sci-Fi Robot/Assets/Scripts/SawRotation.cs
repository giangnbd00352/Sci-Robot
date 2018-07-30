using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour {


    AudioManager audioManager;

    public float speed;
	// Use this for initialization
	void Start () {
        audioManager = AudioManager.instance;

        audioManager.PlaySound("Band Saw");

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
