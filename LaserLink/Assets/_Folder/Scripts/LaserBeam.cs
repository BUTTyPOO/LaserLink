using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;
    
    void Start()
    {
        lineRenderer ??= GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hitInfo;
        Vector3 rayOrigin = transform.TransformPoint(lineRenderer.GetPosition(0));
        Ray ray = new Ray(rayOrigin, transform.forward);

        if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
        {
            lineRenderer.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));
            if (hitInfo.collider.TryGetComponent<ILaserable>(out var laserable))
                laserable.Lasered();
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, 100));
        }
    }
}
