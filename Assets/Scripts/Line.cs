using System.Linq;
using System.Collections.Generic;
using UnityEngine;

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
            for(int i = 0; i < points.Count; i++)
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
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SurfaceEffector2D>().speed = -20;
        }
        else
        {
            GetComponent<SurfaceEffector2D>().speed = 20;
        }
    }
}