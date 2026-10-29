using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Move 입력을 받아 플레이어를 XZ 평면에서 이동시킨다.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private float _moveSpeed = 5f;

    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();
    private void Update() => Move();

    private void Move()
    {
        Vector2 input = _moveInput.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y);

        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void BindInputActions()
    {
        _moveInput.action.Enable();
    }

    private void UnbindInputActions()
    {
        _moveInput.action.Disable();
    }
}
