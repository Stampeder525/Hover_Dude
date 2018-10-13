using UnityEngine;
using System.Collections;

public class BgOffset : MonoBehaviour {

    public float scrollSpeed;
    public Renderer rend;

    void Start () {
        rend = GetComponent<Renderer>();
    }

    void Update () {
        float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2 (x, 0);
        rend.sharedMaterial.SetTextureOffset ("_MainTex", offset);
    }

}