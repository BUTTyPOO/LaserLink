using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using TMPro;

public class LaserPlacer : MonoBehaviour
{
    public TMP_Text tmp;

    [SerializeField] Transform laserParent;
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
        GameObject lasersText = GameObject.FindWithTag("LasersLeftText");
        tmp = lasersText.GetComponent<TMP_Text>();
    }

    void Update()
    {
        print(SubjectScript.instance.lasersPlaced);
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
            } else if (Input.GetMouseButtonDown(1))
            {
                RemoveLaserAtGhostTransform();
            }
        }
        else
        {   // Hide laser somewhere off screen when we are no longer hovering over obj
            ghostPlacementIndicator.transform.localPosition = new Vector3(1000, 1000, 1000);
        }
    }

    void RemoveLaserAtGhostTransform()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.tag == "LaserPrefab")
            {
                Destroy(hitInfo.collider.transform.parent.gameObject);
                tmp.text = (SubjectScript.instance.lasersAllowed - (--SubjectScript.instance.lasersPlaced)).ToString();
            }
        }
    }
    void SpawnLaserAtGhostTransform()
    {
        if (ghostLaserScript.isBlocked == true) return;
        if (SubjectScript.instance.lasersAllowed <= SubjectScript.instance.lasersPlaced) return;
        Vector3 pos = ghostPlacementIndicator.transform.localPosition;
        Quaternion rot = ghostPlacementIndicator.transform.localRotation;

        GameObject spawnedLaser = Instantiate(laserPrefab, pos, rot);
        spawnedLaser.transform.parent = hitData.transform;

        serializedTrans.Add(new SerializedTransform(spawnedLaser.transform));
        tmp.text = (SubjectScript.instance.lasersAllowed - (++SubjectScript.instance.lasersPlaced)).ToString();
    }

    [Button]
    public void DeleteAllLasers()
    {
        foreach(Transform tran in laserParent)
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
