using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {
    public float radius;
    public float pelletSpeed = 500;
    private Vector3 cursorPos;
    public GameObject pelletObj;
    public GameObject controller;
    private ControllerInputScript controls;
	// Use this for initialization
	void Start () {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        controls = controller.GetComponent<ControllerInputScript>();

	}
	
	// Update is called once per frame
	void Update () {
        float joystickX = controls.getRightStickX();
        float joystickY = controls.getRightStickY();
        Vector3 joystickVec = new Vector3(joystickX, joystickY, 0);
        if (controls.getRightTriggerDown())
        {
            if (joystickVec != Vector3.zero)
            {
                GameObject pellet = Instantiate(pelletObj, transform.position, Quaternion.identity);
                pellet.GetComponent<Rigidbody2D>().AddForce(joystickVec * pelletSpeed);
            }
            //SHOOT
        }
        cursorPos = joystickVec;
        cursorPos.Normalize();
        cursorPos = cursorPos * radius;
        if(joystickVec != Vector3.zero){
            transform.localPosition = cursorPos;
        }
	}
}
