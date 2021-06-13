using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum Sound {
        MenuMusic,
        LaserSound
    };

    [SerializeField] AudioSource audSrc;

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

    public void PlaySound()
    {
        audSrc.Play();
    }

    void Start()
    {
        PlaySound();
    }
}
