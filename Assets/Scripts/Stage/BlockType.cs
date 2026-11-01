/// <summary>
/// 스테이지를 구성하는 블록의 종류
/// </summary>
public enum BlockType
{
    /// <summary>
    /// 블록이 없는 빈 칸 (기본값)
    /// </summary>
    None = 0,

    /// <summary>
    /// 모든 방향에서 통과할 수 없는 바닥
    /// </summary>
    Ground = 1,

    /// <summary>
    /// 아래에서 위로는 통과할 수 있고, 위에서 아래로는 통과할 수 없는 반바닥
    /// </summary>
    SemiGround = 2,

    /// <summary>
    /// 닿으면 피해를 주는 가시
    /// </summary>
    Spike = 3,

    /// <summary>
    /// 밟으면 잠시 뒤 사라지는 부서지는 블록
    /// </summary>
    Breakable = 4,

    /// <summary>
    /// 밟으면 높이 튀어오르게 하는 점프대
    /// </summary>
    JumpPad = 5
}
