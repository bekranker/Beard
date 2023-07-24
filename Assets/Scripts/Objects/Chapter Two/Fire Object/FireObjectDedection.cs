using UnityEngine;

namespace Chapter2
{
    [RequireComponent(typeof(TagFireObject))]
    public class FireObjectDedection : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _Rb;
        private Vector2 _velocity;


        private void Update()
        {
            _velocity = _Rb.velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out TagIceObject tagIceObject))
            {
                tagIceObject.VaporizeMe();
                _Rb.velocity = _velocity;
            }
        }
    }
}

