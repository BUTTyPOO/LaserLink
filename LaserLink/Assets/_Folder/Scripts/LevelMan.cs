using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour // more like "level settings"
{
    GameObject subject;
    [SerializeField] GameObject prefabSubject;
    [SerializeField] int totalApples;

    void Start()
    {
        subject = GameObject.Find("Subject");
        if (subject != null)
            subject.GetComponent<SubjectWalker>().StartWalking();

        GameMan.instance.InitLevelVals(totalApples);
    }
}
