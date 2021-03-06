﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Mathf;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;
    private int owner; //SET OWNER TO WHOEVER DREW THE LINE
    public float lineFadeTimer = 0.05f;

    List<Vector2> points;

    //void Start()
    //{
    //    lineFadeTimer = maxLineFadeTimer;
    //}

    void Update()
    {
        lineFadeTimer -= Time.deltaTime;
        if ((lineFadeTimer < 0.0f && points.Count > 0) || points.Count > 50)
        {
            points.RemoveAt(0);
            lineFadeTimer = 0.05f;
            //lineRenderer.SetPositions(points);
            lineRenderer.positionCount--;
            for (int i = 0; i < points.Count; i++)
            {
                lineRenderer.SetPosition(i, points[i]);
            }
            edgeCol.points = points.ToArray();
        }
    }

    public void UpdateLine(Vector2 drawCursorPos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(drawCursorPos);
            return;
        }

        if (Vector2.Distance(points.Last(), drawCursorPos) > .1f)
            SetPoint(drawCursorPos);
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCol.points = points.ToArray();
    }

    public void SetOwner(int player)
    {
        owner = player;
        if (owner == 0)
        {
            gameObject.layer = 8;
        }
        else if (owner == 1)
        {
            gameObject.layer = 9;
        }
    }

    public int GetOwner() {
        return owner;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 direction = coll.gameObject.GetComponent<Rigidbody2D>().velocity;
        GetComponent<AreaEffector2D>().forceAngle = Vector2.Angle(direction, new Vector2(1,0));
    }
}