using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PersistantCanvas : MonoBehaviour
{
    public static UI_PersistantCanvas instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
