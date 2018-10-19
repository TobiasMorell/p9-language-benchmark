using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3D : MonoBehaviour {
    public float Scale(Vector3 v, float scale)
    {
        var vScaled = v * scale;
        return vScaled.x;
    }

    public float Multiply(Vector3 v1, Vector3 v2)
    {
        var vMult = new Vector3(v1.x * v2.x, v2.y * v2.y, v1.z * v2.z);
        return vMult.x;
    }

    public float Translate(Vector3 v1, Vector3 trans)
    {
        var vTranslated = v1 + trans;
        return vTranslated.x;
    }

    public float Subtract(Vector3 v1, Vector3 sub)
    {
        var vSub = v1 - sub;
        return vSub.x;
    }

    public float Length(Vector3 v)
    {
        return v.magnitude;
    }

    public float Dot(Vector3 v1, Vector3 v2)
    {
        var dot = Vector3.Dot(v1, v2);
        return dot;
    }
}
