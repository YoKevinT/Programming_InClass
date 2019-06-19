﻿ using UnityEngine;
using System.Collections;

[AddComponentMenu("Intro PRG/RPG/Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    #region Variables
    [Header("Rotational Axis")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    [Range(0, 20)]
    public float sensitivityX = 15.5f;
    public float sensitivityY = 15.5f;
    [Header("Y Rotation Clamp")]
    public float minY = -60;
    public float maxY = 60;
    float rotationY = 0;
    #endregion
    #region Start
    private void Start()
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    #endregion
    #region Update
    private void Update()
    {
        #region Mouse X and Y
        if (axis == RotationalAxis.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        #endregion
        #region Mouse X
        else if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }

        #endregion
        #region Mouse Y
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }
    }
    #endregion
    #endregion

    #region RotationalAxis
    public enum RotationalAxis
    {
        MouseXandY = 0,
        MouseX,
        MouseY
    }
    #endregion
}