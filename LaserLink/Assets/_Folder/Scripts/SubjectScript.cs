using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectScript : MonoBehaviour
{
    static SubjectScript instance;
    [SerializeField] public int lasersAllowed = 2;
    [SerializeField] public int lasersPlaced = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
