using System;
using UnityEngine;

namespace InteractingObjects
{
    public class TagNormalJumpadObject : MonoBehaviour
    {
        [SerializeField, Range(0.05f, 15)] private int _JumpForce;
        [SerializeField] private Vector2Int _Direction;


        private Vector2 _direction;

        public void JumpObject(Rigidbody2D rb)
        {
            SetVelocityToZero(rb);
            JumpObject(_Direction, rb);
        }

        private void JumpObject(Vector2 direction, Rigidbody2D rb)
        {
            rb.AddForce(_JumpForce * direction, ForceMode2D.Impulse);
        }
        private void SetVelocityToZero(Rigidbody2D rb) => rb.velocity = Vector2.zero;
    }
}