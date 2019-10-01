using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatTilingChange : MonoBehaviour
{
    private Renderer rend;
    public float Speed;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float offset = Time.time * Speed;
        rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
    }
}
