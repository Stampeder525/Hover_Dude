using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameOver : MonoBehaviour {
    private bool the_gameOver;
    private bool restart;
    public Text gameOverText;
    public Text restartText;
    //public GameObject winner;
    //public GameObject restartButton;




	// Use this for initialization
	void Start () {
        the_gameOver = false;
        //restart = false;
        //restartButton.SetActive(false);
        //winner.SetActive(false);
        gameOverText.text = "";
        restartText.text = "";


	}
	

    public void GameOver()

    {
        //winnerText.text = "";
        restartText.text = "Press Down on the D-Pad to Restart";
        //winner.SetActive(true);
        gameOverText.text = "Game Over!";
        the_gameOver = true;



    }
}
