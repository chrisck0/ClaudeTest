using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Move 입력의 x값(A/D)으로 Rigidbody2D를 좌우 이동시킨다.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rigidbody;

    private void Awake() => CacheComponents();

    private void OnEnable() => BindInputActions();

    private void FixedUpdate() => Move();

    private void OnDisable() => UnbindInputActions();

    private void Move()
    {
        float inputX = _moveInput.action.ReadValue<Vector2>().x;
        _rigidbody.linearVelocity = new Vector2(inputX * _moveSpeed, _rigidbody.linearVelocity.y); // 중력에 의한 낙하를 유지하기 위해 y 속도는 그대로 둠
    }

    private void BindInputActions()
    {
        _moveInput.action.Enable();
    }

    private void UnbindInputActions()
    {
        _moveInput.action.Disable();
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
