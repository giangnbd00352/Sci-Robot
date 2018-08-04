using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGame : MonoBehaviour {

    public Button btnBullet;
    public Button btnPause;
    public GameObject panelBullet;
    public GameObject Robot;
    //public GameObject panelLoading;

    public Button btnExit;
	// Use this for initialization
	void Awake () {
        btnBullet.onClick.AddListener(() => {
            //panelLoading.SetActive(true);
            btnPause.gameObject.SetActive(false);
            btnBullet.gameObject.SetActive(false);
            panelBullet.SetActive(true);
        });

        btnExit.onClick.AddListener(() => {
            //panelLoading.SetActive(true);
            btnPause.gameObject.SetActive(true);
            btnBullet.gameObject.SetActive(true);
            panelBullet.SetActive(false);
        });

        
    }

}
