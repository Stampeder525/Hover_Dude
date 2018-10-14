
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int maxScore = 3;
    public int numPlayers = 2;
    public GameObject[] controllers;
    private ControllerInputScript controls;

    public GameObject[] players;
    public Vector2[] startingLocations;
    private int round = 0;
    private int p1Score = 0;
    private int p2Score = 0;
    private bool roundOver = false;
    private int loser = 0;

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
            startingLocations[i] = players[i].GetComponent<Rigidbody2D>().position;
        }

        round = PlayerPrefs.GetInt("Round");
        p1Score = PlayerPrefs.GetInt("P1Score");
        p2Score = PlayerPrefs.GetInt("P2Score");

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

        if (roundOver)
        {
            //Check which player is still alive, increment scores accordingly
            if(loser == 0)
            {
                //Increment player2 score and restart
                p2Score++;
                players[1].GetComponent<PlayerController>().destroyEntireTrail();
            }
            else
            {
                //Increment player1 score
                p1Score++;
                players[0].GetComponent<PlayerController>().destroyEntireTrail();
            }
            if (p1Score >= maxScore)
            {
                //Display "Congratulations p1!"
                //Buttons: Return to Menu, Play Again
                PlayerPrefs.SetInt("Round", 0);
            }
            else if (p2Score >= maxScore)
            {
                //Display "Congratulations p2!"
                //Buttons: Return to Menu, Play Again
                PlayerPrefs.SetInt("Round", 0);
            }
            else
            {
                //Display "Winner: (winner)"
                //Display progress tokens
                //Set player scores
                PlayerPrefs.SetInt("Round", round++);

                //return players to starting locations
                for  (int i = 0; i < numPlayers; i++) {
                    players[i].GetComponent<Rigidbody2D>().position = startingLocations[i];
                }
            }
        }

    }

    public GameObject GetController(int playerNumber)
    {
        //Debug.Log(controllers[playerNumber]);
        return controllers[playerNumber];
    }

    public void EndRound(int player)
    {
        roundOver = true;
        loser = player;
    }
}
