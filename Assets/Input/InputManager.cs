using UnityEngine;
using UnityEngine.InputSystem;



public class InputManager : MonoBehaviour
{
    public static bool TouchDown, TouchUp, Touch;
    public static Vector2 FingerPosition;
    public PlayerInput PlayerInput;

    
    
    private InputAction TouchPositionAction, TouchAction;
    private Camera _mainCamera;
    private Touch _touch;
    private Vector3 touchPosition;
    private int _touchCount;



    private void Awake()
    {
        TouchPositionAction = PlayerInput.actions["TouchPosition"];
        TouchAction = PlayerInput.actions["TouchAction"];
    }
    private void Start()
    {
        _mainCamera = Camera.main;
        _touch = new Touch();

    }

    private void Update()
    {
        _touchCount = Input.touchCount;

        if (_touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            touchPosition = _mainCamera.ScreenToWorldPoint(_touch.position);
            touchPosition.z = 0;
        }
        TouchUp = Input.GetMouseButtonUp(0);
        TouchDown = Input.GetMouseButtonDown(0);
    }

    private void OnEnable()
    {
        TouchPositionAction.performed += ActionFingerPosition;
        TouchAction.performed += ActionTouch;
    }
    private void OnDisable()
    {
        TouchPositionAction.performed -= ActionFingerPosition;
        TouchAction.performed -= ActionTouch;
    }
    public void ActionFingerPosition(InputAction.CallbackContext context)
    {
        FingerPosition = context.ReadValue<Vector2>();
    }
    public void ActionTouch(InputAction.CallbackContext context)
    {
        Touch = context.ReadValueAsButton();
    }
}
