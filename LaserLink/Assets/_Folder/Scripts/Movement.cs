using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate (Vector3.left * 5f * Time.deltaTime); 
        }
        if (Input.GetKey (KeyCode.W)) {
            transform.Translate (Vector3.forward * 5f * Time.deltaTime); 
        }
        if (Input.GetKey (KeyCode.S)) {
            transform.Translate (Vector3.back * 5f * Time.deltaTime); 
        }
        if (Input.GetKey (KeyCode.D)) {
            transform.Translate (Vector3.right * 5f * Time.deltaTime); 
        }
    }
}
