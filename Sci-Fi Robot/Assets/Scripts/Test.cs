using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour {
    public GameObject PositionDiamond_1;
	// Use this for initialization
	void Start () {
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject instance = Instantiate(Resources.Load("Diamond", typeof(GameObject)), PositionDiamond_1.transform) as GameObject;
        instance.transform.position = new Vector3(0,0,0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
