using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Move 입력을 받아 플레이어를 XZ 평면에서 이동시키고, Jump 입력을 받아 지상에서 점프시킨다.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private InputActionReference _jumpInput;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _groundCheckDistance = 1.1f; // 오브젝트 중심에서 발밑까지의 거리 + 여유값

    private Rigidbody _rigidbody;

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();
    private void Update() => Move();

    private void Move()
    {
        Vector2 input = _moveInput.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y);

        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!IsGrounded())
        {
            return;
        }

        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void BindInputActions()
    {
        _moveInput.action.Enable();
        _jumpInput.action.Enable();
        _jumpInput.action.performed += OnJump;
    }

    private void UnbindInputActions()
    {
        _moveInput.action.Disable();
        _jumpInput.action.Disable();
        _jumpInput.action.performed -= OnJump;
    }
}
