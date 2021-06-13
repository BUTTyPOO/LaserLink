using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedTransform
{
    public float[] position = new float[3];
    public float[] rotation = new float[4];
    public float[] scale = new float[3];


    public SerializedTransform(Transform transform)
    {
        position[0] = transform.localPosition.x;
        position[1] = transform.localPosition.y;
        position[2] = transform.localPosition.z;

        rotation[0] = transform.localRotation.w;
        rotation[1] = transform.localRotation.x;
        rotation[2] = transform.localRotation.y;
        rotation[3] = transform.localRotation.z;

        scale[0] = transform.localScale.x;
        scale[1] = transform.localScale.y;
        scale[2] = transform.localScale.z;
    }
}

public static class SerializedTransformExtention
{
    public static void DeserialTransform(this SerializedTransform _serializedTransform, Transform _transform)
    {
        _transform.localPosition = new Vector3(_serializedTransform.position[0], _serializedTransform.position[1], _serializedTransform.position[2]);
        _transform.localRotation = new Quaternion(_serializedTransform.rotation[1], _serializedTransform.rotation[2], _serializedTransform.rotation[3], _serializedTransform.rotation[0]);
        _transform.localScale = new Vector3(_serializedTransform.scale[0], _serializedTransform.scale[1], _serializedTransform.scale[2]);
    }
}

public static class TransformExtention
{
    public static void SetTransformEX(this Transform original, Transform copy)
    {
        original.position = copy.position;
        original.rotation = copy.rotation;
        original.localScale = copy.localScale;
    }
}

