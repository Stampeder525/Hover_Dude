﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawController : MonoBehaviour {
    public float radius;
    public GameObject linePrefab;
    private Line activeLine;
    private Vector3 cursorPos;
    private float lerpFract;
    private float angle;
    public GameObject controller;
    private ControllerInputScript controls;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lerpFract = 0.3f;
        angle = Vector3.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position, transform.position - transform.parent.position);
        controls = controller.GetComponent<ControllerInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.getADown()) {
            transform.parent.gameObject.GetComponent<PlayerController>().destroyEntireTrail();
            Camera.main.GetComponent<Shake>().shakeDuration = 0.5f;

        }


        if (controls.getLeftTriggerDown())
        {
            GameObject line = Instantiate(linePrefab);
            activeLine = line.GetComponent<Line>();
            activeLine.SetOwner(transform.parent.GetComponent<PlayerController>().GetPlayerNumber());
        }
        if (controls.getLeftTriggerUp())
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
        angle = Vector2.Angle(joystickVec, ballVec);
        if (angle >= 30)
        {
            lerpFract = 0.3f;
        }
        else
        {
            lerpFract = 0.4f;
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
