using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 점프 입력 시 플레이어가 땅에 있을 때만 점프시킨다.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionReference _jumpInput;
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.05f;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!IsGrounded())
        {
            return;
        }

        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }

    private bool IsGrounded()
    {
        Bounds bounds = _collider.bounds;
        Vector2 castSize = new Vector2(bounds.size.x * 0.9f, bounds.size.y); // 옆면이 벽에 닿아도 땅으로 판정되지 않도록 폭을 줄임

        return Physics2D.BoxCast(bounds.center, castSize, 0f, Vector2.down, _groundCheckDistance, _groundLayer);
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void BindInputActions()
    {
        _jumpInput.action.Enable();
        _jumpInput.action.performed += OnJump;
    }

    private void UnbindInputActions()
    {
        _jumpInput.action.Disable();
        _jumpInput.action.performed -= OnJump;
    }
}
