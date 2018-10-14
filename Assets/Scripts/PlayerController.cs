using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    public int playerNumber = 0;
    private bool dead = false;

	void Start () {

    }

    // Update is called once per frame
    void Update () {


    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    void OnCollisionEnter2D(Collision coll)
    {
        if(coll.gameObject.tag == "pellet")
        {
            if (coll.gameObject.GetComponent<Pellet>().GetOwner()){
                dead = true;

            }
        }
    }
}
