using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    private Vector3 vel;
    private float timeX, timeY;

	void Start () {
        float scale = Random.Range(20, 35);
        transform.localScale = new Vector3(scale, scale);
        vel = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        timeX = Time.fixedTime;
        timeY = Time.fixedTime;
    }
	
	void Update () {

        if (Mathf.Abs(transform.position.x - 356f) > 330f && timeX + 1 < Time.fixedTime) {
            vel.x *= -1;
            timeX = Time.fixedTime;
        }
        if (Mathf.Abs(transform.position.y - 203f) > 180f && timeY + 1 < Time.fixedTime) {
            vel.y *= -1;
            timeY = Time.fixedTime;
        }
        transform.Translate( vel * Time.deltaTime * Random.Range(15f, 75f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shot(Clone)") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
