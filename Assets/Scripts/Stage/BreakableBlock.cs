using UnityEngine;

/// <summary>
/// 플레이어가 위에서 밟으면 잠시 뒤 사라지고, 일정 시간이 지나면 다시 생기는 블록.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class BreakableBlock : Block
{
    [SerializeField] private float _breakDelay = 3f;
    [SerializeField] private float _respawnDelay = 5f;

    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private bool _isBreaking;
    private float _nextStateTime;

    /// <inheritdoc/>
    public override BlockType BlockType => BlockType.Breakable;

    private void Awake() => CacheComponents();
    private void Update() => UpdateBreaking();
    private void OnCollisionEnter2D(Collision2D collision) => StartBreaking(collision);

    private void StartBreaking(Collision2D collision)
    {
        if (_isBreaking || !IsPlayer(collision.gameObject) || !IsSteppedOn(collision))
        {
            return;
        }

        _isBreaking = true;
        _nextStateTime = Time.time + _breakDelay;
    }

    // 밟힘 → (_breakDelay 뒤) 사라짐 → (_respawnDelay 뒤) 다시 생김
    private void UpdateBreaking()
    {
        if (!_isBreaking || Time.time < _nextStateTime)
        {
            return;
        }

        if (_collider.enabled)
        {
            SetVisible(false);
            _nextStateTime = Time.time + _respawnDelay;
        }
        else
        {
            SetVisible(true);
            _isBreaking = false;
        }
    }

    private void SetVisible(bool isVisible)
    {
        _collider.enabled = isVisible;
        _spriteRenderer.enabled = isVisible;
    }

    private void CacheComponents()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
