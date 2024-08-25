using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiInfo : MonoBehaviour
{
    public int MochiIndex = 0;
    public int PointsWhenDestroyed = 1;
    public float MochiMass = 1f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.mass = MochiMass;
    }
}
