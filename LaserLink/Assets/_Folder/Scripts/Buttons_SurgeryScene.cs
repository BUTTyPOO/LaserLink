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
    }
    void StartButton() // start button
    {
        SceneManager.LoadScene("Level1"); // later change to support more levels
    }
    void ClearButton()
    {
        GameObject.FindObjectOfType<LaserPlacer>().DeleteAllLasers();
        laserInfo.lasersPlaced = 0;
        tmp.text = laserInfo.lasersAllowed.ToString();
    }
}
