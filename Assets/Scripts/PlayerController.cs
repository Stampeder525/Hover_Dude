﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    private int playerNumber = 0;

	void Start () {
    }

    // Update is called once per frame
    void Update () {

        //Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //transform.up = dir * -1f;

    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}
