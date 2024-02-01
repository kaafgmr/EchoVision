using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera cam;

    [Range(0.1f,4f)]
    [SerializeField] float MouseSensitivity = 2;

    float RotationX;
    float RotationY;

    private void Start()
    {
        InitCameraMovement();
    }

    public void InitCameraMovement()
    {
        RotationX = cam.transform.eulerAngles.x;
        RotationY = cam.transform.eulerAngles.y;
    }
    public void MoveCameraWithMouse()
    {
        RotationX -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        RotationY += Input.GetAxis("Mouse X") * MouseSensitivity;

        RotationX = Mathf.Clamp(RotationX, -80f, 80f);

        cam.transform.eulerAngles = new Vector3(RotationX, RotationY, 0);
    }
}