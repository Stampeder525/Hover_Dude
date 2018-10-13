using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject controller;
    private ControllerInputScript controls;

    // Use this for initialization
    void Start () {
        controls = controller.GetComponent<ControllerInputScript>();
    }

    // Update is called once per frame
    void Update () {
        if (controls.getDPadDownDown())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
