/// <summary>
/// 모든 방향에서 통과할 수 없는 바닥 블록. 충돌은 콜라이더가 처리한다.
/// </summary>
public class GroundBlock : Block
{
    /// <inheritdoc/>
    public override BlockType BlockType => BlockType.Ground;
}
