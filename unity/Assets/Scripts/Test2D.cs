using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2D {
    public float Scale(Vector2 v, float scale)
    {
        var vScaled = v * scale;
        return vScaled.x;
    }

    public float Multiply(Vector2 v1, Vector2 v2)
    {
        var vMult = v1 * v2;
        return vMult.x;
    }

    public float Translate(Vector2 v1, Vector2 trans)
    {
        var vTranslated = v1 + trans;
        return vTranslated.x;
    }

    public float Subtract(Vector2 v1, Vector2 sub)
    {
        var vSub = v1 - sub;
        return vSub.x;
    }

    public float Length(Vector2 v)
    {
        return v.magnitude;
    }

    public float Dot(Vector2 v1, Vector2 v2)
    {
        var dot = Vector2.Dot(v1, v2);
        return dot;
    }

}
