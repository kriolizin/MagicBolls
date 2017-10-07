using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class GameControlBehavior : MonoBehaviour
{
    public float k = 0;
    public float forceBarier = 0;

    private Vector2 vecF;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CircleBehavior tmp1 in GetComponentsInChildren<CircleBehavior>())
        {
            vecF = new Vector2(0, 0);
            foreach (CircleBehavior tmp2 in GetComponentsInChildren<CircleBehavior>())
            {
                if (tmp1 == tmp2) continue;

                vecF += GetForce(tmp1.transform.position, tmp2.transform.position, tmp1.charge, tmp2.charge);
            }
            tmp1.GetComponent<Rigidbody2D>().AddForce(vecF);
        }
    }

    private Vector2 GetForce(Vector2 tmp1, Vector2 tmp2, float q1, float q2)
    {
        float f = FunctionCoulomb(q1, q2, Norm(tmp1, tmp2), k);

        if (f > forceBarier)
        {
            f = forceBarier;
        }

        Vector2 singleVector = GetSingleVector(tmp1, tmp2);

        return singleVector * f;
    }

    private float FunctionCoulomb(float q1, float q2, float r, float k)
    {
        float r2 = r * r;
        if (r2 == 0)
            r2 = 0.00001f;
        return (k * q1 * q2) / r2;
    }

    private Vector2 GetSingleVector(Vector2 tmp1, Vector2 tmp2)
    {
        float x = (tmp1.x - tmp2.x) / Norm(tmp1, tmp2);
        float y = (tmp1.y - tmp2.y) / Norm(tmp1, tmp2);

        return new Vector2(x, y);
    }

    private float Norm(Vector2 pos1, Vector2 pos2)
    {
        float norm = (float)Math.Sqrt(
            (pos2.x - pos1.x) *
            (pos2.x - pos1.x) +
            (pos2.y - pos1.y) *
            (pos2.y - pos1.y));
        if (norm == 0)
            norm = 0.00001f;
        return norm;
    }
}
