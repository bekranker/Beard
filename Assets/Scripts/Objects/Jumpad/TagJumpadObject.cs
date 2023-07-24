using InteractingObjects;
using States;
using UnityEngine;

public class TagJumpadObject : MonoBehaviour
{
    [SerializeField, Range(0.05f, 15)] private int _JumpForce;
    [SerializeField] private Vector2Int _Direction;
    [SerializeField] private ObjectManager _ObjectManager;

    private Vector2 _direction;


    public void JumpObject(Rigidbody2D rb, ObjectManager objectManager)
    {
        if(_ObjectManager.MyState(ObjectState.Freeze)) return;
        if (objectManager.myState == ObjectState.WithoutBeard) return;

        _ObjectManager.DedectionAction(objectManager);
        _direction = new Vector2(Mathf.Clamp(rb.velocity.x, -1, 1), 1);
        SetVelocityToZero(rb);
        JumpObject(_direction, rb);
        return;
    }

    private void JumpObject(Vector2 direction, Rigidbody2D rb)
    {
        rb.AddForce(_JumpForce * direction, ForceMode2D.Impulse);
    }
    private void SetVelocityToZero(Rigidbody2D rb) => rb.velocity = Vector2.zero;
}