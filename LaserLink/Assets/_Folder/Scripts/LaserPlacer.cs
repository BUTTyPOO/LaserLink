using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class LaserPlacer : MonoBehaviour
{
    [SerializeField] bool enabled = true;


    [SerializeField] List<SerializedTransform> serializedTrans = new List<SerializedTransform>();

    [SerializeField] LayerMask layerMask;
    [SerializeField] Camera cam;
    [SerializeField] GameObject ghostPlacementIndicator;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject subject;    // the object we are placing lasers on

    LaserGhostIndicator ghostLaserScript;
    RaycastHit hitData;

    void Start()
    {
        ghostLaserScript ??= ghostPlacementIndicator.GetComponentInChildren<LaserGhostIndicator>();
    }

    void Update()
    {
        if (!enabled)
            return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitData, 1000, layerMask))
        {
            ghostPlacementIndicator.transform.localRotation = Quaternion.LookRotation(hitData.normal);
            ghostPlacementIndicator.transform.localPosition = hitData.point;

            if (Input.GetMouseButtonDown(0))
            {
                SpawnLaserAtGhostTransform();
            }
        }
        else
        {   // Hide laser somewhere off screen when we are no longer hovering over obj
            ghostPlacementIndicator.transform.localPosition = new Vector3(1000, 1000, 1000);
        }
    }

    void SpawnLaserAtGhostTransform()
    {
        if (ghostLaserScript.isBlocked == true) return;

        Vector3 pos = ghostPlacementIndicator.transform.localPosition;
        Quaternion rot = ghostPlacementIndicator.transform.localRotation;

        GameObject spawnedLaser = Instantiate(laserPrefab, pos, rot);
        spawnedLaser.transform.parent = hitData.transform;

        serializedTrans.Add(new SerializedTransform(spawnedLaser.transform));
    }

    [Button]
    void DeleteAllLasers()
    {
        foreach(Transform tran in subject.transform)
        {
            Destroy(tran.gameObject);
        }
        // laserCords.Clear();
    }

    [Button]
    void AttachAllLasers()
    {
        foreach(SerializedTransform tran in serializedTrans)
        {
            GameObject spawnedObj = Instantiate(laserPrefab);
            spawnedObj.transform.parent = subject.transform;
            tran.DeserialTransform(spawnedObj.transform);
        }
    }
}
