using UnityEngine;

/// <summary>
/// 플레이어가 닿아 있는 동안 피해를 주는 가시 블록. 콜라이더는 Trigger로 설정해야 한다.
/// </summary>
public class SpikeBlock : Block
{
    /// <inheritdoc/>
    public override BlockType BlockType => BlockType.Spike;

    // 닿아 있는 동안 계속 호출하고, 연속 피해는 PlayerHealth의 무적 시간이 막음
    private void OnTriggerStay2D(Collider2D other) => DamagePlayer(other);

    private void DamagePlayer(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage();
        }
    }
}
