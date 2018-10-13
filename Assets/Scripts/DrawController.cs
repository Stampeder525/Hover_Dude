using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour {
    public float radius;
    private Vector3 cursorPos;
    private float lerpSpeed;
    private float angle;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        lerpSpeed = 0.4f;
        angle = cursorPos.x;
    }
	
	// Update is called once per frame
	void Update () {

        cursorPos = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f); //CHANGE MOUSE TO CONTROLLER INPUT
        angle += cursorPos.x;
        Vector2 offset = (Vector2)cursorPos - Vector2.zero;
        offset.Normalize();
        offset = offset * radius;
        transform.position = offset;
    }
}
