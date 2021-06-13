using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sound {
        MenuMusic,
        LaserSound
    };

    [SerializeField] AudioSource audSrc;
    
    public void PlaySound()
    {
        audSrc.Play();
    }

    void Start()
    {
        PlaySound();
    }
}
