using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryCamController : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] Camera cam;
    [SerializeField] Transform cameraPivotHorizontal;
    [SerializeField] Transform cameraPivotVert;

    [Header("Settings")]
    [SerializeField] float horizontalSpeed = 40f;
    [SerializeField] float vertSpeed = 40f;
    [SerializeField] float zoomSpeed = 10f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateHorizontal();
            RotateVertical();
        }

        float scrollDel = Input.mouseScrollDelta.y * zoomSpeed;
        float targetFOV = cam.fieldOfView + scrollDel;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * 0.5f);
    }

    void RotateHorizontal()
    {
        float rotAmmount = Input.GetAxisRaw("Mouse X") * horizontalSpeed;
        cameraPivotHorizontal.Rotate(Vector3.up, rotAmmount);
    }

    void RotateVertical()
    {
        float rotAmmount = Input.GetAxisRaw("Mouse Y") * vertSpeed;
        cameraPivotVert.Rotate(-Vector3.right, rotAmmount);
    }
}