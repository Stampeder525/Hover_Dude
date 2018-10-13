using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour {
    public float radius;
    private Vector3 cursorPos;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
    }
	
	// Update is called once per frame
	void Update () {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        //angle += cursorPos.x;
        Vector2 offset = (Vector2)cursorPos - Vector2.zero;
        offset.Normalize();
        offset = offset * radius;
        transform.position = offset;
        Vector2 dir = cursorPos - this.transform.position;
        //Check if dir is negative, then reverse
        if (Mathf.Abs(cursorPos.x) <= 2f && Mathf.Abs(cursorPos.y) <= 2f)
        {
            dir = -1 * dir;
        }
    }
}
