using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;


public class LaserGhostIndicator : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public bool isBlocked { get; private set; }   // Changed with SetIsBlocked

    Renderer renderr;
    Material mat;
    BoxCollider ghostCol;

    void Start()
    {
        ghostCol = GetComponentInChildren<BoxCollider>();
        renderr = GetComponentInChildren<Renderer>();
        mat = renderr.material;
    }

    public void Update()
    {
        CheckIfBlocked();
    }

    public void MakeRed()
    {
        mat.SetColor("_Color", Color.red);
    }

    void MakeGrey()
    {
        mat.SetColor("_Color", Color.grey);
    }

    void SetIsBlocked(bool val) // Updates material to be red or grey based on 
    {
        if (val == true)
            MakeRed();
        else
            MakeGrey();

        isBlocked = val;
    }

    void CheckIfBlocked()
    {
        RaycastHit hitInfo;
        if (Physics.BoxCast(transform.position, Vector3.one, transform.forward, out hitInfo, transform.rotation, 1000, layerMask, QueryTriggerInteraction.Collide))
        {
            Destroy(hitInfo.transform.gameObject);
            MakeRed();
        }
        else
        {
            MakeGrey();
        }
    }
}
