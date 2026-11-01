using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 좌우 이동 입력으로 플레이어를 이동시키고, 마지막으로 이동한 방향을 바라보는 방향으로 기억한다.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private PlayerDash _dash;
    private float _moveDirection;

    /// <summary>
    /// 플레이어가 바라보는 방향 (오른쪽 1, 왼쪽 -1)
    /// </summary>
    public float FacingDirection { get; private set; } = 1f;

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();
    private void FixedUpdate() => Move();

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<float>();

        if (_moveDirection != 0f)
        {
            FacingDirection = Mathf.Sign(_moveDirection);
        }
    }

    private void Move()
    {
        // 대시 중에는 대시가 속도를 제어하므로 이동 입력을 무시함
        if (_dash != null && _dash.IsDashing)
        {
            return;
        }

        _rigidbody.linearVelocity = new Vector2(_moveDirection * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _dash = GetComponent<PlayerDash>();
    }

    private void BindInputActions()
    {
        _moveInput.action.Enable();
        _moveInput.action.performed += OnMove;
        _moveInput.action.canceled += OnMove;
    }

    private void UnbindInputActions()
    {
        _moveInput.action.Disable();
        _moveInput.action.performed -= OnMove;
        _moveInput.action.canceled -= OnMove;
    }
}
