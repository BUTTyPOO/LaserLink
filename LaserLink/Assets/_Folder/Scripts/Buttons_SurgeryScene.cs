using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_SurgeryScene : MonoBehaviour
{
    public void StartButton() // start button
    {
        SceneManager.LoadScene("Level1"); // later change to support more levels
    }
}
