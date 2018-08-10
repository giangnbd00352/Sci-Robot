using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGame : MonoBehaviour {

    public Button btnBullet;
    public Button btnPause;
    public GameObject panelBullet;
    public GameObject panelLoading;

    public Button btnExit;
    public RobotController robot;
    public ServiceGame service;
    // Use this for initialization
    void Awake () {
        btnBullet.onClick.AddListener(() => {
            panelLoading.SetActive(true);           
            robot.RobotAction = false;
            btnPause.gameObject.SetActive(false);
            btnBullet.gameObject.SetActive(false);
            panelBullet.SetActive(true);
            service.Load();
        });

        btnExit.onClick.AddListener(() => {
            //panelLoading.SetActive(true);
            robot.RobotAction = true;
            btnPause.gameObject.SetActive(true);
            btnBullet.gameObject.SetActive(true);
            panelBullet.SetActive(false);
        });

        
    }

}
