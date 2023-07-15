using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace InteractingObjects
{
    [RequireComponent(typeof(MetalObjectManager))]

    public class MetalObjectsDedection : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private Vector2 _velocity;
        
        
        
        private void Update()
        {
            _velocity = _rb.velocity;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out WoodObjectManager woodObjectManager))
            {
                woodObjectManager.BreakMe(_velocity.magnitude);
                _rb.velocity = _velocity;
            }
        }
    }
}
