using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour {

    private int owner;
    public float knockback;

    void Start()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Collided with my own path like a sad sack of shit");
        }

        if (collision.gameObject.tag == "pellet")
        {

            if (collision.gameObject.GetComponent<Pellet>().GetOwner() == GetOwner())
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), GetComponent<CapsuleCollider2D>());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().GetPlayerNumber() == GetOwner())
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), GetComponent<CapsuleCollider2D>());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "line")
        {
            if (collision.gameObject.GetComponent<Line>().GetOwner() == GetOwner())
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<EdgeCollider2D>(), GetComponent<CapsuleCollider2D>());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetOwner(int player)
    {
        owner = player;
    }

    public int GetOwner()
    {
        return owner;
    }
}
