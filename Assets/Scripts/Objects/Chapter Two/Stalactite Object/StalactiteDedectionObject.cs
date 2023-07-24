using InteractingObjects;
using UnityEngine;


namespace Chapter2
{
    public class StalactiteDedectionObject : MonoBehaviour
    {
        public bool Hited;
        [SerializeField] private LayerMask TargetLayers;
        [SerializeField] private Rigidbody2D _Rb;
        private bool _didHit = false;


        private void Update()
        {
            Raytacsing();
            if (_didHit)
            {
                _Rb.isKinematic = false;
                _didHit = false;
            }
        }
        private void Raytacsing()
        {
            if (_didHit) return;
            if (Hited) return;
            Hited = Physics2D.Raycast(transform.position, Vector2.down, 20, TargetLayers);
            _didHit = Hited;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
            {
                objectManager.ChangeState(States.ObjectState.Freeze);
                gameObject.SetActive(false);
            }
        }
    }
}