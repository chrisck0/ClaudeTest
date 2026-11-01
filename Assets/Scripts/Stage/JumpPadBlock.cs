using UnityEngine;

/// <summary>
/// 플레이어가 위에서 밟는 순간 높이 튀어오르게 하는 점프대 블록.
/// </summary>
public class JumpPadBlock : Block
{
    [SerializeField] private float _launchSpeed = 20f;

    /// <inheritdoc/>
    public override BlockType BlockType => BlockType.JumpPad;

    private void OnCollisionEnter2D(Collision2D collision) => Launch(collision);

    private void Launch(Collision2D collision)
    {
        if (!IsPlayer(collision.gameObject) || !IsSteppedOn(collision))
        {
            return;
        }

        Vector2 velocity = collision.rigidbody.linearVelocity;
        collision.rigidbody.linearVelocity = new Vector2(velocity.x, _launchSpeed);
    }
}
