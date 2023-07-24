using InteractingObjects;
using UnityEngine;

public class JumpadDedection : MonoBehaviour
{
    [Space(15)]
    [Header("-----Components-----")]
    [Space(15)]
    [SerializeField] private TagJumpadObject _JumpadManager;
    private bool _didJump;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_didJump) return;

        if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
        {
            _JumpadManager.JumpObject(collision.gameObject.GetComponent<Rigidbody2D>(), objectManager);
            _didJump = true;
        }
    }
}
