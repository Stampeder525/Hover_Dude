using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour {

    private int owner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("Collided with my own path like a sad sack of shit");
        }
        Destroy(gameObject);
    }

    public void SetOwner(int player)
    {
        owner = player;
    }

    public void GetOwner()
    {
        return owner;
    }
}
