using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour {

    public GameObject Flash;

    bool flicker = true;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(FlashFlicker());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FlashFlicker()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("Update" + Time.time);
        flicker = !flicker;
        Flash.SetActive(flicker);
        StartCoroutine(FlashFlicker());

    }
}
