using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum FireTypes { Projectile, Raycast };

public abstract class Weapon : Item
{
    public FireTypes FireType;
    public IFireType FT;
    public Ammunition Ammo;
    public int MagCapacity, LoadedRounds, Damage, Penetration;
    public float ProjectileForce;
    public Transform ShootOrigin;

    public void Initialize()
    {
        ShootOrigin = transform;
        switch (FireType)
        {
            case FireTypes.Projectile:
                FT = ScriptableObject.CreateInstance<ProjectileBasedFire>();
                break;
            case FireTypes.Raycast:
                FT = ScriptableObject.CreateInstance<RaycastBasedFire>();
                break;
            default:
                Debug.LogError ("IFireType injection error");
                break;

        }
    }

    //TODO: Implement weapon functionality.
    public virtual void Fire()
    {
        if (LoadedRounds > 0)
        {
            FT.Shoot (ShootOrigin);
            LoadedRounds -= 1;
        }
        else
        {
            EmptyClick ();
        }
        return;

    }

    protected virtual void EmptyClick()
    {
        throw new NotImplementedException ();
    }

    public virtual void AlternativeFire()
    {
        throw new NotImplementedException ();
    }
    public virtual void Reload()
    {
        throw new NotImplementedException ();
    }
    public virtual void Unload()
    {
        throw new NotImplementedException ();
    }
    public virtual void ADS()
    {
        throw new NotImplementedException ();
    }

    private void Start()
    {
        Initialize ();
    }

}

