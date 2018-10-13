using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ControllerInputScript : MonoBehaviour {
	private InputDevice inputDevice;
	public int playerNumber;

	// Use this for initialization
	void Start ()
    {
        inputDevice = InputManager.Devices[0];

    }

    // Update is called once per frame
    void Update () {
		inputDevice = InputManager.Devices[0];
	}

	public float getLeftStickX() {
		return inputDevice.LeftStickX;
	}

	public float getLeftStickY() {
		return inputDevice.LeftStickY;
	}

	public float getRightStickX() {
		return inputDevice.RightStickX;
	}

	public float getRightStickY() {
		return inputDevice.RightStickY;
	}

    public bool getRightTriggerDown()
    {
        return inputDevice.GetControl(InputControlType.RightTrigger).WasPressed;
    }

    public bool getRightTriggerUp()
    {
        return inputDevice.GetControl(InputControlType.RightTrigger).WasReleased;
    }


}
