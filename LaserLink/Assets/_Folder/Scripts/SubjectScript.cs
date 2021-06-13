using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectScript : MonoBehaviour
{
    public static SubjectScript instance;
    [SerializeField] public int lasersAllowed = 2;
    [SerializeField] public int lasersPlaced;
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

    void Update()
    {
        lasersAllowed = GameMan.instance.levelIndex + 1;
    }
}
