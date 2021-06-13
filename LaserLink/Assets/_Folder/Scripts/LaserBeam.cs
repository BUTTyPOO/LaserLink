using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;

    public void Lasered()
    {
        Destroy(gameObject);
    }
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
            ILaserable laserable = hitInfo.collider.GetComponent<ILaserable>();
            if(laserable != null)
                laserable.Lasered();
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, 100));
        }


        // print(rayOrigin);
        // GameObject abba = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // abba.transform.localPosition = rayOrigin;
        // abba.transform.localScale *= .05f;
    }
}
