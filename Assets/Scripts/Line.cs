using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;

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

}