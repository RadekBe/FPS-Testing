using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private static CameraControls _instance { get; }

    public bool visibleCursor;
    public static Camera Cam;
    public float SensX,SensY;
   
    private float mX, mY,parentRotX;

    void Start()
    {
        if (Cam == null)
            Cam = Camera.main;

        Cursor.visible = visibleCursor;
    }

    void Update()
    {
        mX += Input.GetAxis ("Mouse X") * SensX;
        mY -= Input.GetAxis ("Mouse Y") * SensY;

        //Debug.Log ("mX: " + mX + " mY: " + mY);

        mY = Mathf.Clamp (mY,-90f, 90f);
        //mX = Mathf.Clamp (mX, -180f, 180f);

        //Parent rotations
        this.transform.eulerAngles = new Vector3 (0f, mX, 0f);
        parentRotX = this.transform.eulerAngles.y;

        //Camera only rotations
        this.transform.eulerAngles = new Vector3(mY, parentRotX, 0f); 

    }
}
