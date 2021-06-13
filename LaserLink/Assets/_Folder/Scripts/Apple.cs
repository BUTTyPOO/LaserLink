using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ILaserable
{
    public void Lasered()
    {
        GameMan.instance.AppleSliced();
        Destroy(gameObject);
    }
}
