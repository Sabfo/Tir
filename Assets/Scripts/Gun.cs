using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform originalTarget, originalShot;

    private GameObject cam;
    private Vector3 mousePos;
    private int amountTargets = 10;
    private float timeForGame = 12;
    private float startTime;

    private void OnEnable() {
        startTime = Time.fixedTime;
        for (int i = 0; i < amountTargets; i++)
            Instantiate(originalTarget, new Vector3(Random.Range(50f, 660f), Random.Range(50f, 360f), 2f), Quaternion.identity);
    }

    void Start () {
        cam = GameObject.Find("Main Camera");
    }
	
	void Update () {
        if (Time.fixedTime - startTime > timeForGame)
            cam.GetComponent<Reference>().EndGame("LOSE");
        if (Time.timeScale != 0) 
            LookAtMouse();

    }

    private void LookAtMouse() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.right, mousePos - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePos.y ? angle : -angle);
    }

    public void setTimeForGame(float x)
    {
        timeForGame = x;
    }

    public float getTimeForGame()
    {
        return timeForGame;
    }

    public void setAmountTargets(int x)
    {
        amountTargets = x;
    }

    public int getAmountTargets()
    {
        return amountTargets;
    }

    public float getStartTime()
    {
        return startTime;
    }

    public void Fire() {
        Debug.Log("Fire");
        Instantiate(originalShot, transform.position, transform.rotation);
    }

}
