# Player

## 개요

플레이어 입력 중 A/D 키로 플레이어를 좌우로 이동시키는 시스템이다.
이동은 물리(Rigidbody2D)로 처리하며, 수직 방향은 중력에 맡긴다.

- 관련 입력 : `PlayerInputActions`의 `Player/Move` (WASD)
- 관련 프리팹 : 없음 (Player가 아직 프리팹이 아님)

## 구조

| 클래스 | 역할 |
| --- | --- |
| `PlayerMovement` (`Assets/Scripts/Player/PlayerMovement.cs`) | Move 입력의 x값(A/D)을 읽어 플레이어를 좌우로 이동시킨다. |

`PlayerMovement`는 아래 대상에 의존한다.

- `Rigidbody2D` : 같은 GameObject에 붙어 있으며, 이동 속도를 적용하는 대상이다.
- `InputActionReference` : Inspector에서 `PlayerInputActions`의 `Player/Move` 액션을 연결받아 입력 값을 읽는다.

## 동작 흐름

1. 컴포넌트가 활성화되면 Move 입력을 활성화한다.
2. 물리 갱신마다 Move 입력의 x값에 이동 속도를 곱해 수평 속도로 설정한다. 수직 속도는 기존 값을 그대로 유지한다.
3. 컴포넌트가 비활성화되면 Move 입력을 비활성화한다.

## 설계 결정

| 결정 | 근거 | 고르지 않은 대안 |
| --- | --- | --- |
| W/S는 바인딩만 하고 사용하지 않음 | 사용자 선택 | 네 방향 이동, 중력 0 |
| 수직 속도 유지 | 중력에 의한 낙하를 유지하기 위함 (구현 브리핑) | 없음 |
| `InputActionReference`로 입력 참조 | `TechSpec.md`의 유저 입력 시스템 | 구 InputManager |
| Rigidbody2D 회전 고정 (FreezeRotation) | 사용자 승인 (모서리에 걸려 넘어지는 것을 방지) | 없음 |
