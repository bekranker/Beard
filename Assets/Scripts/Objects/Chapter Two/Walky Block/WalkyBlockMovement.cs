using UnityEngine;

[RequireComponent(typeof(TagWalkyBlock))]
public class WalkyBlockMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _Rb;
    [SerializeField] private float _Speed;
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Transform _RightRayTransform, _LeftRayTransform;
    [SerializeField] private int direction;

    private void FixedUpdate()
    {
        _Rb.velocity = new Vector2(direction * _Speed, _Rb.velocity.y);
        SetRotation();
    }
    private void SetRotation()
    {
        if (Physics2D.Raycast(_RightRayTransform.position, Vector2.right, 0.5f, _LayerMask))
        {
            direction = -1;
        }
        if (Physics2D.Raycast(_LeftRayTransform.position, Vector2.left, 0.5f, _LayerMask))
        {
            direction = 1;
        }
    }
}