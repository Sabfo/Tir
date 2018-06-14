using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reference : MonoBehaviour {

    public GameObject Gun, PauseMenu, Interface, MainMenu;
    public Text txtState, txtTarget, txtTime, textTarget, textTime;

    private GameObject[] Targets, Shots;
    private int oldValue = -1;
    private float oldTime = 0;

	void Start () {
        Time.timeScale = 0;
        textTarget = Interface.transform.GetChild(0).GetComponent<Text>();
        textTime = Interface.transform.GetChild(1).GetComponent<Text>();
        txtState = PauseMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        txtTarget = PauseMenu.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        txtTime = PauseMenu.transform.GetChild(0).GetChild(2).GetComponent<Text>();
    }
	
	void Update () {
        if(Time.timeScale != 0) {
            Targets = GameObject.FindGameObjectsWithTag("Target");
            if(Targets.Length != oldValue) { 
                textTarget.text = "Targets destroy: " + (Gun.GetComponent<Gun>().getAmountTargets() - Targets.Length) + " / " + Gun.GetComponent<Gun>().getAmountTargets();
                oldValue = Targets.Length;
            }
            if (Time.time + 1 > oldTime) { 
                oldTime++;
                textTime.text = "Time: " + oldTime + " / " + Gun.GetComponent<Gun>().getTimeForGame();
            }
            if (Targets.Length == 0)
                EndGame("WIN");
        }

	}

    public void EndGame(string state) {
        Time.timeScale = 0;
        float t;
        if (Time.fixedTime - Gun.GetComponent<Gun>().getStartTime() > Gun.GetComponent<Gun>().getTimeForGame())
            t = Gun.GetComponent<Gun>().getTimeForGame();
        else
            t = Time.fixedTime - Gun.GetComponent<Gun>().getStartTime();
        txtTime.text = "Time: " + t + " / " + Gun.GetComponent<Gun>().getTimeForGame();
        txtTarget.text = "Targets destroy: " + (Gun.GetComponent<Gun>().getAmountTargets() - Targets.Length) + " / " + Gun.GetComponent<Gun>().getAmountTargets();
        txtState.text = state;
        PauseMenu.SetActive(true);
        Interface.SetActive(false);
    }

    public void CleanLevel() {
        Debug.Log("Clear");
        Targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject obj in Targets)
            Destroy(obj);
        Shots = GameObject.FindGameObjectsWithTag("Shot");
        foreach (GameObject obj in Shots)
            Destroy(obj);
    }
}
