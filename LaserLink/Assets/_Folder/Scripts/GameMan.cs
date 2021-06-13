using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMan : MonoBehaviour
{
    public static GameMan instance;
    public int applesHit; // set by LevelMan
    public int totalApples; // set by LevelMan
    public int levelIndex = 1; // Build index of next level
    public int MAX_LEVEL = 1; // Build index of next level

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

    public void DidIWin()
    {
        if (applesHit == totalApples)
            LevelWon();
        else
            GameOverLevel();
    }

    public void LevelWon()
    {
        if (levelIndex >= MAX_LEVEL)
            levelIndex = 1;
        levelIndex++;

        // UI
        // Convete
        // Make Subject Celeberatry
        GameObject.FindObjectOfType<UI_GameWonPanel>().OpenUI();
        print("Level Won!");
    }

    public void GameOverLevel()
    {
        print("GameOver");
        GameObject.FindObjectOfType<UI_GameOverPanel>().OpenUI();
    }

    public void InitLevelVals(int totalApples)
    {
        this.applesHit = 0;
        this.totalApples = totalApples;
    }

    public  void AppleSliced()  // called by apple when they get lasered
    {
        SoundManager.instance.PlayWatermelonSFX();
        applesHit += 1;
        FindObjectOfType<UI_ApplesLeftWidget>().UpdateTally();
    }
}
