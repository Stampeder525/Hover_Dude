using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawController : MonoBehaviour {
    public float radius;
    public GameObject linePrefab;
    private Line activeLine;

    private Vector3 cursorPos;
    private float lerpFract;
    private float angle;
    public GameObject controller;
    private ControllerInputScript controls;
    private TrailRenderer trail;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        lerpFract = 0.3f;
        trail = gameObject.GetComponent<TrailRenderer>();
        angle = Vector3.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position, transform.position - transform.parent.position);
        controls = controller.GetComponent<ControllerInputScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controls.getRightTriggerDown())
        {
            GameObject line = Instantiate(linePrefab);
            activeLine = line.GetComponent<Line>();
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
        if (controls.getRightTriggerUp())
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            activeLine.UpdateLine(transform.position);
        }
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
        cursorPos = Vector3.Lerp(transform.position - transform.parent.position, joystickVec, lerpFract);
        //Vector2 offset = (Vector2)cursorPos - (Vector2)transform.parent.position; //HERE'S THE PROBLEM
        cursorPos.Normalize();
        //offset.Normalize();
        //offset = offset * radius;
        cursorPos = cursorPos * radius;
        transform.localPosition = cursorPos;
    }

    public float GetLerpFract()
    {
        return lerpFract;
    }
}
