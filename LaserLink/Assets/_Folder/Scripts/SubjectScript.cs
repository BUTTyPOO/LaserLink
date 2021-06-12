using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectScript : MonoBehaviour
{
    [SerializeField] public int lasersAllowed = 2;
    [SerializeField] public int lasersPlaced = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
