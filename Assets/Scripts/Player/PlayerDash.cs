using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 대시 입력 시 바라보는 방향으로 일정 시간 수평 대시하고, 대시가 끝난 뒤 쿨타임을 적용한다.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerMovement))]
public class PlayerDash : MonoBehaviour
{
    [SerializeField] private InputActionReference _dashInput;
    [SerializeField] private float _dashSpeed = 20f;
    [SerializeField] private float _dashDuration = 0.15f;
    [SerializeField] private float _dashCooldown = 0.5f;

    private Rigidbody2D _rigidbody;
    private PlayerMovement _movement;
    private float _originalGravityScale;
    private float _dashDirection;
    private float _dashEndTime;
    private float _nextDashTime;

    /// <summary>
    /// 현재 대시 중인지 여부
    /// </summary>
    public bool IsDashing { get; private set; }

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();
    private void FixedUpdate() => UpdateDash();

    private void OnDash(InputAction.CallbackContext context)
    {
        if (IsDashing || Time.time < _nextDashTime)
        {
            return;
        }

        StartDash();
    }

    private void StartDash()
    {
        IsDashing = true;
        _dashDirection = _movement.FacingDirection;
        _dashEndTime = Time.time + _dashDuration;
        _nextDashTime = _dashEndTime + _dashCooldown;

        // 공중 대시 중 아래로 떨어지지 않도록 중력을 끔
        _originalGravityScale = _rigidbody.gravityScale;
        _rigidbody.gravityScale = 0f;
    }

    private void UpdateDash()
    {
        if (!IsDashing)
        {
            return;
        }

        if (Time.time >= _dashEndTime)
        {
            EndDash();
            return;
        }

        _rigidbody.linearVelocity = new Vector2(_dashDirection * _dashSpeed, 0f);
    }

    private void EndDash()
    {
        IsDashing = false;
        _rigidbody.gravityScale = _originalGravityScale;
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void BindInputActions()
    {
        _dashInput.action.Enable();
        _dashInput.action.performed += OnDash;
    }

    private void UnbindInputActions()
    {
        _dashInput.action.Disable();
        _dashInput.action.performed -= OnDash;
    }
}
