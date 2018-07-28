using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGame : MonoBehaviour {

    public Button btnBullet;
    public GameObject panelBullet;
    //public GameObject panelLoading;

    public Button btnExit;
	// Use this for initialization
	void Awake () {
        btnBullet.onClick.AddListener(() => {
            //panelLoading.SetActive(true);
            panelBullet.SetActive(true);
        });

        btnExit.onClick.AddListener(() => {
            //panelLoading.SetActive(true);
            panelBullet.SetActive(false);
        });
    }

}
