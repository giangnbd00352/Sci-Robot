using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    int gamePoint = 0;
    public Text txtPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Score: " + gamePoint.ToString();
    }
}
