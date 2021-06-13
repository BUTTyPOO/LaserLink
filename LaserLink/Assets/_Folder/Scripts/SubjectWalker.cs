using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using DG.Tweening;

public class SubjectWalker : MonoBehaviour  // makes subject walk
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;


    [Button]
    public void StartWalking()
    {
        FindPoints();
        TeleportToPointA();
        transform.DOMove(pointB.position, 10f);
    }

    void FindPoints()
    {
        pointA = GameObject.Find("Point A").transform;
        pointB = GameObject.Find("Point B").transform;
    }

    void TeleportToPointA()
    {
        transform.position = pointA.position;
    }
}
