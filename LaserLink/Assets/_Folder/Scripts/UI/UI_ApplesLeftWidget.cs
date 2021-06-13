using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UI_ApplesLeftWidget : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    int totalApples;
    int applesLeft;

    // Start is called before the first frame update
    void Start()
    {
        txt ??= transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateTally()
    {
        AnimateTxt();
        totalApples = GameMan.instance.totalApples;
        applesLeft = GameMan.instance.applesHit;
        txt.text = applesLeft.ToString() + '/' + totalApples.ToString();
    }

    void AnimateTxt()
    {
        txt.transform.DOComplete();
        txt.transform.DOPunchScale(txt.transform.localPosition * 1.5f, 0.2f);   // dosen't work for some reason
    }
}
