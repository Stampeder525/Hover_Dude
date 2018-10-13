
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int numPlayers = 2;
    public GameObject[] controllers;
    private ControllerInputScript controls;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < numPlayers; i++)
        {
            ControllerInputScript controls = controllers[i].GetComponent<ControllerInputScript>();
            controls.SetPlayerNumber(i);
        }


        //controls = controller.GetComponent<ControllerInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        for (int i = 0; i < numPlayers; i++)
        {
            if (controllers[i].GetComponent<ControllerInputScript>().getDPadDownDown())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public GameObject GetController(int playerNumber)
    {
        //Debug.Log(controllers[playerNumber]);
        return controllers[playerNumber];
    }
}
