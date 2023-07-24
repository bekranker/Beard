using UnityEngine;

namespace InteractingObjects
{
    [RequireComponent(typeof(TagNormalJumpadObject))]
    public class NormalJumpadDedectionManager : MonoBehaviour
    {
        [Space(15)]
        [Header("-----Components-----")]
        [Space(15)]
        [SerializeField] private TagNormalJumpadObject _JumpadManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
            {
                _JumpadManager.JumpObject(collision.gameObject.GetComponent<Rigidbody2D>());
            }
        }
    }
}

