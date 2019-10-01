using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class ProjectileBasedFire : ScriptableObject, IFireType
{
    public Ammunition Projectile;
    public float Force;

    private Rigidbody rb;

    public ProjectileBasedFire( float force, Ammunition ammo)
    {
        Force = force;
        Projectile = ammo;
    }

    public void Shoot(Transform origin)
    {
        GameObject projectile = Instantiate (Projectile.Prefab, origin.position, Quaternion.identity) as GameObject;
        rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce (Vector3.forward * Force, ForceMode.Impulse);
    }
}

