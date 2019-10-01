using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJump : MonoBehaviour
{
    public float Force;

    private void OnCollisionEnter( Collision collision )
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rg = collision.gameObject.GetComponent<Rigidbody> ();
            rg.AddForce (Vector3.up * Force, ForceMode.VelocityChange);
            Debug.Log ("Power Jump!");
        }


    }
}
