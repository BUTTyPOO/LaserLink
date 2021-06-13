using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ILaserable
{
    public SoundManager soundMngr;

    public void Lasered()
    {
        soundMngr.PlayWatermelonSFX();
        Destroy(gameObject);
    }
}
