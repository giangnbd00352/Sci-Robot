using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour {

    public Image LoadingCircle;
    public Text txtLoading;
    // Use this for initialization
    void Start () {
        StartCoroutine(Loading());
    }
	
	// Update is called once per frame
	void Update () {
        LoadingCircle.rectTransform.Rotate(0, 0, -200 * Time.deltaTime);
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        txtLoading.text += ".";
        if (txtLoading.text.Length > 10)
        {
            txtLoading.text = "Loading.";
        }
        StartCoroutine(Loading());
    }
}
