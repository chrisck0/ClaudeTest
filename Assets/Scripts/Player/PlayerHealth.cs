using System;
using UnityEngine;

/// <summary>
/// 플레이어의 HP를 관리한다. 데미지를 입으면 HP가 1 감소하고 일정 시간 무적이 되며, HP가 0이 되면 사망한다.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    private const int MAX_HEALTH = 3;

    [SerializeField] private float _invincibleDuration = 1.5f;

    private float _invincibleEndTime;

    /// <summary>
    /// 현재 HP
    /// </summary>
    public int CurrentHealth { get; private set; }

    /// <summary>
    /// HP가 0이 되어 사망했을 때 발생하는 이벤트
    /// </summary>
    public event Action OnDied;

    private void Awake() => CurrentHealth = MAX_HEALTH;

    /// <summary>
    /// 데미지를 입혀 HP를 1 감소시킴. 무적 시간 중이거나 이미 사망한 상태면 무시
    /// </summary>
    public void TakeDamage()
    {
        if (CurrentHealth <= 0 || Time.time < _invincibleEndTime)
        {
            return;
        }

        CurrentHealth--;
        _invincibleEndTime = Time.time + _invincibleDuration;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke();
        gameObject.SetActive(false);
    }
}
