using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject pelletObject = coll.gameObject;
        if(pelletObject.tag == "pellet")
        {
            
            Pellet pellet = pelletObject.GetComponent<Pellet>();
            if (pellet.GetOwner() != playerNumber){
                this.applyImpact(pellet.knockback, pelletObject.GetComponent<Rigidbody2D>().velocity);
                this.destroyEntireTrail();
                Camera.main.GetComponent<Shake>().shakeDuration = 0.5f;

                dead = true;

                IEnumerator coroutine = WaitAndRestart(1.0f);

                StartCoroutine(coroutine);
            }
        }
    }

    private IEnumerator WaitAndRestart(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameManager.instance.EndRound(playerNumber);
        

        }
    }

    private void applyImpact(float knockback, Vector2 direction) {
        Rigidbody2D rb = transform.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * knockback, ForceMode2D.Impulse);
    }

    public void destroyEntireTrail() {
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject rootObject in rootObjects) {
            if (rootObject.tag == "line") {
                if (rootObject.GetComponent<Line>().getOwner() == playerNumber) {
                    Destroy(rootObject);
                }
            }
        }
    }

}
 