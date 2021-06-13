using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryCamController : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 40f;
    [SerializeField] float vertSpeed = 40f;
    [SerializeField] Transform cameraPivotHorizontal;
    [SerializeField] Transform cameraPivotVert;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateHorizontal();
            RotateVertical();
        }

        if (Input.mouseScrollDelta.)
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