using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ControllerInputScript : MonoBehaviour {
	private InputDevice inputDevice;
	private int playerNumber;


    // Update is called once per frame
    void Update () {
		inputDevice = InputManager.Devices[playerNumber];
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

    public bool getDPadDownDown()
    {
        return inputDevice.GetControl(InputControlType.DPadDown).WasPressed;
    }

    public void SetPlayerNumber(int pNum)
    {
        playerNumber = pNum;
        inputDevice = InputManager.Devices[playerNumber];
    }


}
