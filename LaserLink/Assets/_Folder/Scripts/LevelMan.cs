using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    GameObject subject;
    [SerializeField] GameObject prefabSubject;

    void OnEnable()
    {
        subject = GameObject.Find("Subject");
        if (subject == null)
        {
            Instantiate(prefabSubject).GetComponent<SubjectWalker>().StartWalking();
        }
        else
            subject.GetComponent<SubjectWalker>().StartWalking();
    }
}
