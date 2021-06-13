using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    public GameObject panel;
    public void OpenPanel()
    {
        if(!panel.activeInHierarchy)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
}
