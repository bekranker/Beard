using UnityEngine;


namespace Chapter1
{
    [RequireComponent(typeof(TagMetalObject))]

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
            if (collision.gameObject.TryGetComponent(out TagWoodObject woodObjectManager))
            {
                woodObjectManager.BreakMe(_velocity.magnitude);
                _rb.velocity = _velocity;
            }
        }
    }
}
