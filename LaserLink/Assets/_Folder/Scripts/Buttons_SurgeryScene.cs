using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons_SurgeryScene : MonoBehaviour
{
    public TMP_Text tmp;
    public SubjectScript laserInfo;
    [SerializeField] GameObject subject;    // the object we are placing lasers on
    void Start()
    {
        laserInfo = subject.GetComponent<SubjectScript>();
        GameObject lasersText = GameObject.FindWithTag("LasersLeftText");
        tmp = lasersText.GetComponent<TMP_Text>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void StartButton() // start button
    {
        SceneManager.LoadScene(GameMan.instance.levelIndex); // later change to support more levels
    }

    void ClearButton()
    {
        GameObject.FindObjectOfType<LaserPlacer>().DeleteAllLasers();
        laserInfo.lasersPlaced = 0;
        tmp.text = GameMan.instance.levelIndex + 1.ToString();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        tmp.text = GameMan.instance.levelIndex + 1.ToString();
    }
}
