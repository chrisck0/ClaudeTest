using UnityEngine;

/// <summary>
/// 아래에서 위로는 통과할 수 있고, 위에서 아래로는 통과할 수 없는 반바닥 블록. 한쪽 통과는 PlatformEffector2D가 처리한다.
/// </summary>
[RequireComponent(typeof(PlatformEffector2D))]
public class SemiGroundBlock : Block
{
    /// <inheritdoc/>
    public override BlockType BlockType => BlockType.SemiGround;
}
