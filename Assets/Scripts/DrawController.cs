using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour {
    public float radius;
    private Vector3 cursorPos;
    private float lerpFract;
    private float angle;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        lerpFract = 0.3f;

        angle = Vector3.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position, transform.position - transform.parent.position);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        Vector3 ballVec = transform.position - transform.parent.position;
        angle = Vector2.Angle(mouseVec,ballVec);
        if (angle >= 30)
        {
            lerpFract = 0.1f;
        }
        else
        {
            lerpFract = 0.3f;
        }
        Debug.Log("Angle: " + angle + ", LerpFract: " + lerpFract);
        cursorPos = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), lerpFract); //CHANGE MOUSE TO CONTROLLER INPUT
        Vector2 offset = (Vector2)cursorPos - Vector2.zero;
        offset.Normalize();
        offset = offset * radius;
        transform.position = offset;
    }
}
