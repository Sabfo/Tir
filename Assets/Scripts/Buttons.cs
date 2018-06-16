using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    private GameObject PauseMenu, Interface, MainMenu, Gun, Camera;

	void Start () {
        Camera = GameObject.Find("Main Camera");
        Gun       = Camera.GetComponent<Reference>().Gun;
        Interface = Camera.GetComponent<Reference>().Interface;
        PauseMenu = Camera.GetComponent<Reference>().PauseMenu;
        MainMenu = Camera.GetComponent<Reference>().MainMenu;
    }
	
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        Debug.Log(gameObject.name);
        switch (gameObject.name)
        {
            case "modeEasy":
                Gun.GetComponent<Gun>().setAmountTargets(7);
                Gun.GetComponent<Gun>().setTimeForGame(30);
                Gun.SetActive(true);
                MainMenu.SetActive(false);
                PauseMenu.SetActive(false);
                Interface.SetActive(true);
                Time.timeScale = 1;
                break;
            case "modeNormal":
                Gun.GetComponent<Gun>().setAmountTargets(18);
                Gun.GetComponent<Gun>().setTimeForGame(20);
                Gun.SetActive(true);
                MainMenu.SetActive(false);
                PauseMenu.SetActive(false);
                Interface.SetActive(true);
                Time.timeScale = 1;
                break;
            case "modeHard":
                Gun.GetComponent<Gun>().setAmountTargets(30);
                Gun.GetComponent<Gun>().setTimeForGame(10);
                Gun.SetActive(true);
                MainMenu.SetActive(false);
                PauseMenu.SetActive(false);
                Interface.SetActive(true);
                Time.timeScale = 1;
                break;
            case "Pause":
                Time.timeScale = 0;
                Camera.GetComponent<Reference>().EndGame("PAUSE");
                PauseMenu.SetActive(true);
                Interface.SetActive(false);
                break;
            case "Restart":
                PauseMenu.SetActive(false);
                Interface.SetActive(true);
                Camera.GetComponent<Reference>().CleanLevel();
                Gun.SetActive(false);
                Gun.SetActive(true);              
                Time.timeScale = 1;
                break;
            case "Resume":
                PauseMenu.SetActive(false);
                Interface.SetActive(true);
                Time.timeScale = 1;
                break;
            case "Exit":
                Camera.GetComponent<Reference>().CleanLevel();
                Gun.SetActive(false);
                MainMenu.SetActive(true);
                PauseMenu.SetActive(false);
                Interface.SetActive(false);
                break;
            case "Place":
                if(Time.timeScale != 0)
                    Gun.GetComponent<Gun>().Fire();
                break;
        }
    }
}
