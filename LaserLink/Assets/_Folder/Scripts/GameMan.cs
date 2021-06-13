using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LevelWon()
    {
        // UI
        // Convete
        // Make Subject Celeberatry
        print("Level Won!");
    }

    public void GameOverLevel()
    {
        print("GameOver");
    }
}
