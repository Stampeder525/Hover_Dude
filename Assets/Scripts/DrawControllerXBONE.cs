using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawControllerXBONE : MonoBehaviour {
    public float radius;
    private Vector3 cursorPos;
    private float lerpFract;
    private float angle;
    private ControllerInputScript controls;
    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        lerpFract = 0.3f;

        angle = Vector3.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position, transform.position - transform.parent.position);
    
        controls = GameObject.Find("ControllerInput").GetComponent<ControllerInputScript>();
    }
	
	// Update is called once per frame
	void Update () {
        float joystickX = controls.getLeftStickX();
        float joystickY = controls.getLeftStickY();
        Vector3 joystickVec = new Vector3(joystickX, joystickY, 0);
        Vector3 ballVec = transform.position - transform.parent.position;
        angle = Vector2.Angle(joystickVec,ballVec);
        if (angle >= 30)
        {
            lerpFract = 0.4f;
        }
        else
        {
            lerpFract = 0.6f;
        }
        // Debug.Log("Angle: " + angle + ", LerpFract: " + lerpFract);
        cursorPos = Vector3.Lerp(transform.position, joystickVec, lerpFract); //CHANGE MOUSE TO CONTROLLER INPUT
        Vector2 offset = (Vector2)cursorPos - Vector2.zero;
        offset.Normalize();
        offset = offset * radius;
        transform.position = offset;
    }
}
