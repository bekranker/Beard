 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{
    [SerializeField, Range(0.05f, 30)] private float MaxVelocity;
    [SerializeField] private Rigidbody2D _Rb;


    private void Update()
    {
        _Rb.velocity = Vector2.ClampMagnitude(_Rb.velocity, MaxVelocity);
    }
}
