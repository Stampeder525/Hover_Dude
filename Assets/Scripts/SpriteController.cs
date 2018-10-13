using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private GameObject controller;
    private ControllerInputScript controls;

    // Use this for initialization
    void Start()
    {
        controller = GameManager.instance.GetController(transform.parent.GetComponent<PlayerController>().GetPlayerNumber());
        controls = controller.GetComponent<ControllerInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float joystickX = controls.getLeftStickX();
        float joystickY = controls.getLeftStickY();
        Vector3 joystickVec = new Vector3(joystickX, joystickY, 0);
        if (joystickVec != Vector3.zero)
        {
            transform.up = joystickVec * -1f;
        }
    }
}
