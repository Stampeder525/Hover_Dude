using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawController : MonoBehaviour {
    public float radius;
    public GameObject linePrefab;
    private Line activeLine;

    private Vector3 cursorPos;
    private float lerpFract;
    private float angle;
    private TrailRenderer trail;

    // Use this for initialization
    void Start () {
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //CHANGE MOUSE TO CONTROLLER INPUT
        lerpFract = 0.3f;
        trail = gameObject.GetComponent<TrailRenderer>();
        angle = Vector3.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position, transform.position - transform.parent.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject line = Instantiate(linePrefab);
            activeLine = line.GetComponent<Line>();
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            activeLine.UpdateLine(transform.position);
        }
        Vector3 mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        Vector3 ballVec = transform.position - transform.parent.position;
        angle = Vector2.Angle(mouseVec,ballVec);
        if (angle >= 30)
        {
            lerpFract = 0.1f;
        }
        else
        {
            lerpFract = 0.3f;
        }
        cursorPos = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), lerpFract); //CHANGE MOUSE TO CONTROLLER INPUT
        Vector2 offset = (Vector2)cursorPos - (Vector2)transform.parent.position; //HERE'S THE PROBLEM
        offset.Normalize();
        offset = offset * radius;
        transform.localPosition = offset;
    }

    public float GetLerpFract()
    {
        return lerpFract;
    }
}
