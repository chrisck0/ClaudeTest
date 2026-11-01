using UnityEngine;

/// <summary>
/// 모든 스테이지 블록의 부모 클래스. 블록 종류와, 여러 블록이 함께 쓰는 판별 기능을 제공한다.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class Block : MonoBehaviour
{
    private const float STEP_TOLERANCE = 0.05f; // 발이 윗면보다 이만큼 아래에 있어도 밟은 것으로 판정

    /// <summary>
    /// 블록의 종류
    /// </summary>
    public abstract BlockType BlockType { get; }

    protected bool IsPlayer(GameObject target)
    {
        return target.TryGetComponent(out PlayerHealth _);
    }

    // collision.otherCollider는 이 블록의 콜라이더, collision.collider는 부딪힌 상대의 콜라이더
    protected bool IsSteppedOn(Collision2D collision)
    {
        return collision.collider.bounds.min.y >= collision.otherCollider.bounds.max.y - STEP_TOLERANCE;
    }
}
