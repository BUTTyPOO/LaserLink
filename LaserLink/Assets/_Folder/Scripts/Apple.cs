using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ILaserable
{
    [SerializeField] GameObject waterMelonRagdoll;
    public void Lasered()
    {
        Instantiate(waterMelonRagdoll, transform.position, Quaternion.identity);
        GameMan.instance.AppleSliced();
        Destroy(gameObject);
    }
}
