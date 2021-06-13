using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    GameObject subject;

    void OnEnable()
    {
        subject = GameObject.Find("Subject");
        subject.GetComponent<SubjectWalker>().StartWalking();
    }
}
