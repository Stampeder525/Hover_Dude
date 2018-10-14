
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int maxScore = 3;
    public int numPlayers = 2;
    public GameObject[] controllers;
    private ControllerInputScript controls;

    public Canvas canvas;
    public GameObject[] players;
    private int round = 0;
    private int p1Score = 0;
    private int p2Score = 0;
    private bool roundOver = false;
    private int loser = 0;

    public Text p1Text;
    public Text p2Text;
    public Text roundText;
    public Text maxScoreText;

    public GameObject panel;
    public Text ready;

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

        round = PlayerPrefs.GetInt("Round");
        p1Score = PlayerPrefs.GetInt("P1Score");
        p2Score = PlayerPrefs.GetInt("P2Score");

        roundText.text = "Round " + round;
        p1Text.text = "" + p1Score;
        p2Text.text = "" + p2Score;
        maxScoreText.text = "First to " + maxScore + " wins!";

        ready.fontSize = 22;
        ready.text = "Ready?";
        yield return new WaitForSeconds(1.0f);
        float waitfor = 2.0f;
        ready.fontSize = 35;
        ready.text = "GO!";
        yield return new WaitForSeconds(1.0f);


    }

    private Ienumerator countdown()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        for (int i = 0; i < numPlayers; i++)
        {
            ControllerInputScript controller = controllers[i].GetComponent<ControllerInputScript>();
            if (controller.getDPadDownDown())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (controller.getLeftBumperDown() && controller.getRightBumperDown()) {
                Debug.Log("doing the reset thing");
                PlayerPrefs.SetInt("P1Score", 0);
                PlayerPrefs.SetInt("P2Score", 0);
                PlayerPrefs.SetInt("Round", 0);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (roundOver)
        {
            //Check which player is still alive, increment scores accordingly
            if(loser == 0)
            {
                //Increment player2 score and restart
                Debug.Log("Player 2 wins");
                Debug.Log("Score before update: " + PlayerPrefs.GetInt("P2Score"));

                PlayerPrefs.SetInt("P2Score", p2Score + 1);
                Debug.Log("Score AFTER update: " + PlayerPrefs.GetInt("P2Score"));

            }
            else
            {
                //Increment player1 score
                Debug.Log("Player 1 wins");
                Debug.Log("Score before update: " + PlayerPrefs.GetInt("P1Score"));
                PlayerPrefs.SetInt("P1Score", p1Score + 1);
                Debug.Log("Score AFTER update: " + PlayerPrefs.GetInt("P1Score"));

            }
            if (p1Score >= maxScore - 1)
            {
                //Display "Congratulations p1!"
                //Buttons: Return to Menu, Play Again
                PlayerPrefs.SetInt("P1Score", 0);
                PlayerPrefs.SetInt("P2Score", 0);
                PlayerPrefs.SetInt("Round", 0);
            }
            else if (p2Score >= maxScore - 1)
            {
                //Display "Congratulations p2!"
                //Buttons: Return to Menu, Play Again
                PlayerPrefs.SetInt("P1Score", 0);
                PlayerPrefs.SetInt("P2Score", 0);
                PlayerPrefs.SetInt("Round", 0);
            }
            else
            {
                //Display "Winner: (winner)"
                //Display progress tokens
                //Set player scores
                
                PlayerPrefs.SetInt("Round", round++);


            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // put this on some "restart" button

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
