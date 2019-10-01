using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    private GameObject wepInstance = null;
    private bool drawn;

    public Weapon weapon;
    public Vector3 Offset;
    public bool Draw;

    void Start()
    {
        if (weapon != null)
        {
            //TODO: check if weapon is a weapon. :) (after implementing weapon class)
            if (wepInstance == null)
            {
                wepInstance = Instantiate (weapon.Prefab,transform.position + Offset, Quaternion.identity) as GameObject;
                wepInstance.transform.SetParent (this.transform);
                //TODO: get weapon component of the weapon prefab.
                wepInstance.SetActive (false);
            }
        }
        else
            Debug.LogError ("Attach weapon prefab!");
    }

    void Update()
    {
        UpdateRotation ();

        if (Draw && !drawn)
            DrawWeapon ();
        else if (!Draw && drawn)
            HideWeapon ();
    }

    private void UpdateRotation()
    {
        wepInstance.transform.rotation = CameraControls.Cam.transform.rotation;
    }

    private void HideWeapon()
    {
        wepInstance.SetActive (false);

        drawn = false;
    }

    private void DrawWeapon()
    {
        
        //TODO: implement animations.
        wepInstance.SetActive (true);

        drawn = true;
    }
}
