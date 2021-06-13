using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ILaserable
{
    public void Lasered()
    {
        print("Lasered");
        Destroy(gameObject);
    }
}
