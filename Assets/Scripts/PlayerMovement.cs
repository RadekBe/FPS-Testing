using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private bool crouched;
    private Vector3 targetVel = new Vector3(0,0,0);

    private Rigidbody rb;
    private CapsuleCollider coll;
    private EquippedWeapon eqWep;

    private float dampening,crouchpen;
    private float iniHeight;
    public bool OnGround;
    public bool Crouching;

    public float MoveSpeed, StrafeSpeed, VelX, VelZ, AirDampening, JumpForce, CrouchHeight, CrouchPenality;

    public Vector3 CrouchVec, CrouchOffset;
    
    private void Controls()
    {
        
        dampening = Mathf.Clamp (AirDampening, 1, Mathf.Infinity);
        //Debug.Log (dampening);

        if (OnGround)
        {
            dampening = 1;
        }
        if (Input.GetButton ("HorizontalKey"))
        {
            targetVel.x = ( StrafeSpeed * Input.GetAxis ("HorizontalKey") );
        }
        else
        {
            targetVel.x = 0f;
        }

        if (Input.GetButton ("VerticalKey"))
        {
            targetVel.z = ( MoveSpeed * Input.GetAxis ("VerticalKey") );
        }
        else
        {
            targetVel.z = 0f;
        }


        if (Input.GetButtonDown ("Jump") && OnGround)
            Jump ();

        if (Input.GetButtonDown ("Crouch"))
        {
            Crouching = true;
        }

        if (Input.GetButtonUp ("Crouch"))
        {
            Crouching = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
            

    }

    private void Fire()
    {
        eqWep.weapon.Fire ();
    }

    private void Jump()
    {
        rb.velocity = new Vector3 (rb.velocity.x, JumpForce, rb.velocity.z);
    }

    private void Crouch()
    {

        if (OnGround)
        {
            crouchpen = CrouchPenality;
            transform.position -= CrouchVec;
        }

        coll.height = CrouchHeight;
        coll.center += CrouchOffset;
        crouched = true;
    }

    private void StandUp()
    {
        crouchpen = 0;

        if(OnGround)
            transform.position += CrouchVec;
        coll.height = 2;
        coll.center -= CrouchOffset;

        crouched = false;
    }

    private void Move()
    {
        //transform.rotation = new Quaternion (0, 0, 0, 0);

        targetVel = transform.TransformDirection (targetVel);
        Vector3 velChange = targetVel - rb.velocity;

        velChange.x = Mathf.Clamp (velChange.x, -VelX, VelX);
        velChange.z = Mathf.Clamp (velChange.z, -VelZ, VelZ);
        velChange.y = 0;
        //apply penalties
        velChange = velChange / ( dampening + crouchpen );
        
        /*addforce to change velocity
         * this produces an error on start
         * however it doesn't seem to affect script behaviour
         * */
        rb.AddForce (velChange, ForceMode.VelocityChange);

        if (Crouching && !crouched)
        {
            Crouch ();
        }
        else if (!Crouching && crouched && CheckStandClearance ())
        {
            StandUp ();
        }
        if (Crouching && !crouched)
            OnGround = true;
        else
            OnGround = false;
    }

    private bool CheckStandClearance()
    {
        RaycastHit hit;
        Debug.DrawLine (transform.position, transform.position + new Vector3 (0, 1 + CrouchVec.y, 0));
        if (Physics.Raycast (transform.position, Vector3.up, out hit, 1 + CrouchVec.y))
            return false;
        else
            return true;
    }

    void Start()
    {
        OnGround = true;
        rb = GetComponent<Rigidbody> ();
        coll = GetComponent<CapsuleCollider> ();
        iniHeight = coll.height;
        eqWep = transform.Find ("WeaponSlot").GetComponent<EquippedWeapon> ();
        /*if(rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody> ();
        }*/
    }

    void Update()
    {
        Controls ();

    }

    void FixedUpdate()
    {
        Move ();
    }

    void OnCollisionStay()
    {
        OnGround = true;
    }
}

