using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject PauseWindow;

    [SerializeField]
    GameObject OptionsWindow;

    [SerializeField]
    GameObject HelpWindow;

    [SerializeField]
    GameObject MenuUI;

    public Button btnPause;

    enum MenuStates { Playing, Pause, Options, Help}
    MenuStates currentState;

    [SerializeField]
    GameObject Robot;


    // Use this for initialization
    void Start () {
        currentState = MenuStates.Playing;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && currentState == MenuStates.Pause)
        {
            currentState = MenuStates.Playing;
        }
        else if (Input.GetKeyDown("escape") && currentState == MenuStates.Playing)
        {
            currentState = MenuStates.Pause;
        }

        btnPause.onClick.AddListener(() => {
            currentState = MenuStates.Pause;
        });

        switch (currentState)
        {
            case MenuStates.Playing:
                currentState = MenuStates.Playing;
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(false);
                Robot.GetComponent<RobotController>().enabled = true;
                Time.timeScale = 1;
                break;
            case MenuStates.Pause:
                PauseWindow.SetActive(true);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(true);
                Robot.GetComponent<RobotController>().enabled = false;
                Time.timeScale = 0;
                break;
            case MenuStates.Options:
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(true);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(true);
                Robot.GetComponent<RobotController>().enabled = false;
                Time.timeScale = 0;
                break;
            case MenuStates.Help:
                PauseWindow.SetActive(false);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(true);
                MenuUI.SetActive(true);
                Robot.GetComponent<RobotController>().enabled = false;
                Time.timeScale = 0;
                break;
        }
	}

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void DisplayOptions()
    {
        currentState = MenuStates.Options;
    }

    public void DisplayHelp()
    {
        currentState = MenuStates.Help;
    }

    public void Resume()
    {
        currentState = MenuStates.Playing;
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void BackButton()
    {
        currentState = MenuStates.Pause;
    }
}
