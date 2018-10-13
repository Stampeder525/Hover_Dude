using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class TestControllerScript : MonoBehaviour {
	public InputDevice inputDevice;

	// Use this for initialization
	void Start () {
		// inputDevice = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {
		var activeDevice = InputManager.ActiveDevice;
		print(activeDevice.LeftStickX);
		transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * activeDevice.LeftStickX, Space.World);
	}
}
