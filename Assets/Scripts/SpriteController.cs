using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.Lerp(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, 0.3f);
        transform.up = dir * -1f;
    }
}
