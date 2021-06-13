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
    [SerializeField] GameAssets gameAsset;
    public void PlaySound()
    {
        audSrc.clip = gameAsset.soundAudioClipArray[0].audioClip;
        audSrc.Play();
    }

    void Start()
    {
        PlaySound();
    }
}
