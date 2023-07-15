using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum JumpadType
{
    CanBeBeard,
    CantBeBeard
}


public class JumpadManager : MonoBehaviour
{
    [SerializeField] private JumpadType _JumpadType;
    [SerializeField, Range(0.05f, 15)] private int _JumpForce;
    [SerializeField] private Vector2Int _Direction;


    private Vector2 _direction;

    public void JumpObject(Rigidbody2D rb)
    {
        switch (_JumpadType)
        {
            case JumpadType.CanBeBeard:
                _direction = new Vector2(Mathf.Clamp(rb.velocity.x, -1, 1), 1);
                SetVelocityToZero(rb);
                JumpObject(_direction, rb);
                break;
            case JumpadType.CantBeBeard:
                SetVelocityToZero(rb);
                JumpObject(_Direction, rb);
                break;
            default:
                break;
        }
    }

    private void JumpObject(Vector2 direction, Rigidbody2D rb)
    {
        rb.AddForce(_JumpForce * direction, ForceMode2D.Impulse);
    }
    private void SetVelocityToZero(Rigidbody2D rb) => rb.velocity = Vector2.zero;
}