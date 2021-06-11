using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_MainMenu : MonoBehaviour
{
    public void StartButton() // start button
    {
        SceneManager.LoadScene("SurgeryScene");
    }
}
