using System;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_PlaceholderLauncherGrenades : Ammunition
{
    public float FuseTime;
    private float fuseElapsed;

    /*private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }*/

    public void Update()
    {
        if (fuseElapsed >= FuseTime)
            Explode ();
        else
            fuseElapsed += Time.deltaTime;
        
    }

    private void Explode()
    {
        Destroy (this.gameObject);
    }

    private void OnCollisionEnter( Collision coll )
    {
        Explode ();
    }
}
