using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundAssets : MonoBehaviour
{
    public AudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
