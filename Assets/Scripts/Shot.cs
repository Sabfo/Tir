using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Mathf.Abs(transform.position.x - 356f) > 500f || Mathf.Abs(transform.position.y - 203f) > 350f)
            Destroy(gameObject);
        transform.Translate(Vector3.right * Time.deltaTime * 600f);
	}
}
