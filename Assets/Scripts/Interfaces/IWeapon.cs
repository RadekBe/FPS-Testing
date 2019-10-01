using System;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * OBSOLETE
 * 
 */

public interface IWeapon
{
    void Fire();
    void AlternativeFire();
    void Reload();
    void Unload();
    void ADS();
}