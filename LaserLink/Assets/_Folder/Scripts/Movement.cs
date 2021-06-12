using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        Vector3 localpos = transform.localPosition;
        localpos.z = localpos.z + 2f * Time.deltaTime;
        transform.localPosition = localpos;
    }
}
