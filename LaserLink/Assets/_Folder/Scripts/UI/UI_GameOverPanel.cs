using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class UI_GameOverPanel : MonoBehaviour
{
    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }

    public void RetryButton() // start button
    {
        SceneManager.LoadScene("SurgeryScene");
    }

    public void OpenUI()
    {
        GetComponent<CanvasGroup>().DOFade(1, 1);
        transform.DOPunchScale(transform.localPosition * 1.3f, 0.3f, 0, 0).SetEase(Ease.InQuad);
    }
}
