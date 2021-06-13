using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Transform subject = GameObject.FindObjectOfType<SubjectScript>().transform;
        subject.localPosition = Vector3.zero;
        subject.localRotation = Quaternion.identity;
    }
}
