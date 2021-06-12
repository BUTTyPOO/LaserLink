using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using TMPro;

public class LaserPlacer : MonoBehaviour
{
    public SubjectScript laserInfo;
    [SerializeField] bool enabled = true;
    public TMP_Text tmp;
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
        laserInfo = subject.GetComponent<SubjectScript>();
        GameObject lasersText = GameObject.FindWithTag("LasersLeftText");
        tmp = lasersText.GetComponent<TMP_Text>();
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
        if (laserInfo.lasersAllowed == laserInfo.lasersPlaced) return;
        Vector3 pos = ghostPlacementIndicator.transform.localPosition;
        Quaternion rot = ghostPlacementIndicator.transform.localRotation;

        GameObject spawnedLaser = Instantiate(laserPrefab, pos, rot);
        spawnedLaser.transform.parent = hitData.transform;

        serializedTrans.Add(new SerializedTransform(spawnedLaser.transform));
        tmp.text = (laserInfo.lasersAllowed - (++laserInfo.lasersPlaced)).ToString();
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
