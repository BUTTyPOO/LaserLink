using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PersistantCanvas : MonoBehaviour
{
    public static UI_PersistantCanvas instance;
    [SerializeField] TextMeshProUGUI txt;
    

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

    public void UpdateStageCount()
    {
        txt.text = "Stage: " + GameMan.instance.levelIndex;
    }
}
