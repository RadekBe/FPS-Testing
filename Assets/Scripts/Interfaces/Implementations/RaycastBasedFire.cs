using System;
using UnityEngine;

[System.Serializable]
public class RaycastBasedFire : MonoBehaviour, IFireType
{
    public float Range;

    private int dmg;
    private RaycastHit hit;
    private Ammunition ammo;

    //constructor
    public RaycastBasedFire(Ammunition am)
    {
        ammo = am;
    }

    public void Shoot( Transform origin )
    {
        if (Physics.Raycast (origin.position, Vector3.forward, out hit, Range))
            CheckHit ();
        else
            return;
    }

    private void CheckHit()
    {
        //TODO: Implement hit checking and damage apply.
        throw new NotImplementedException ();
    }
}