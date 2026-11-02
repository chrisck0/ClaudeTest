# Hierarchy Convention

> 씬의 Hierarchy에 게임 오브젝트를 배치할 때 따르는 규칙이다.

---

## 1. 씬 최상위 구성
씬 루트에는 카테고리용 빈 오브젝트만 두고, 실제 오브젝트는 그 아래에 넣는다.

```
SampleScene
├── Managers        GameManager, AudioManager 등
├── Environment     타일맵, 배경, 지형
├── Characters      Player, Enemy
├── Interactables   아이템, 발판, 함정
├── Cameras         Main Camera, Cinemachine
└── UI              Canvas, EventSystem
```
- 카테고리 오브젝트의 Transform은 Position (0,0,0) / Rotation 0 / Scale 1로 고정하고 컴포넌트는 붙이지 않는다.
- 카테고리는 담을 오브젝트가 생길 때만 만든다. 비어 있는 카테고리는 미리 만들어 두지 않는다.

### 구간 그룹
모든 카테고리 아래에서, 필요하다면 오브젝트를 구간별로 묶는 그룹 오브젝트를 둘 수 있다.

예시 : `Environment` 아래 지형을 구간별로 묶는 경우
```
Environment
├── Section_01
│   ├── Ground_01
│   └── Ground_02
└── Section_02
    └── SemiGround_01
```
- 그룹 오브젝트는 Rotation 0 / Scale 1로 두고 컴포넌트는 붙이지 않는다.
- 그룹 오브젝트의 위치는 자식들을 기준으로 잡는다.
  - X, Z : 자식 위치들의 가운데 (가장 작은 값과 가장 큰 값의 중간)
  - Y : 자식들 중 가장 아래쪽 끝 (바닥에 닿는 지점)
  - 그룹 위치를 옮길 때 자식의 월드 위치가 바뀌지 않도록 한다.

## 2. 개별 오브젝트 구조

### 기본형
```
Player                  ← 루트: Rigidbody2D, Collider2D, 로직 스크립트
└── PlayerVisual        SpriteRenderer, Animator
```
- 물리 컴포넌트(Rigidbody2D, Collider2D)는 루트에 붙인다.
- 로직 스크립트도 기본적으로 루트에 붙인다.
- 비주얼은 `{루트이름}Visual` 자식 오브젝트로 분리한다.
- 좌우 반전 같은 방향 전환은 `{루트이름}Visual`에서만 처리한다.

### 루트 위치 기준
- 루트 오브젝트의 위치는 바닥에 닿는 지점으로 잡는다.
- `{루트이름}Visual`의 위치를 조정해서 스프라이트 아래쪽 끝이 루트 위치에 오도록 맞춘다.
- 루트의 Collider2D는 Offset을 조정해서 아래쪽 끝이 바닥에 맞닿게 한다. Collider가 바닥 아래로 처지지 않도록 한다.

### 로직을 자식 오브젝트로 분리하는 경우
아래 중 하나에 해당하면 로직 스크립트를 루트가 아닌 자식 오브젝트에 붙인다.
1. 루트와 다른 위치에서 동작해야 할 때
2. 루트와 다른 Collider가 필요할 때
3. 루트와 따로 활성화/비활성화해야 할 때

```
Player                  ← 루트: Rigidbody2D, Collider2D, 기본 로직
├── PlayerVisual        SpriteRenderer, Animator
└── PlayerAttack        PlayerAttack.cs, BoxCollider2D (Trigger)
```
- 자식 이름은 붙인 스크립트에 맞는 이름으로 짓는다. (`PlayerAttack`, `PlayerGroundCheck`)
- 자식 로직이 루트의 컴포넌트를 참조하는 방식은 `Docs\Code\CodeConvention.md`를 따른다.

| 위치 | 담는 것 | 담지 않는 것 |
|---|---|---|
| 루트 | 물리 컴포넌트, 기본 로직 스크립트 | 렌더링 컴포넌트 |
| `{이름}Visual` | Sprite, Animator, 파티클 | 게임 규칙을 처리하는 스크립트 |
| `{이름}{기능}` | 분리 기준에 해당하는 로직 스크립트 | 렌더링 컴포넌트 |

## 3. 이름 규칙
- PascalCase를 쓰고 공백은 넣지 않는다. (`EnemySlime`, `MovingPlatform`)
- `GameObject (1)`처럼 Unity가 자동으로 붙인 이름은 그대로 두지 않는다.
- 같은 종류가 여러 개면 `_01`, `_02`처럼 번호를 붙인다.

## 4. UI
```
UI
├── Canvas_HUD
│   ├── HPBar
│   └── ScoreText
├── Canvas_Popup
└── EventSystem
```
- 용도별로 Canvas를 나눈다.

## 5. 프리팹
- 씬에 반복해서 배치하는 오브젝트는 프리팹으로 만들고, 씬에는 프리팹 인스턴스를 배치한다.
- 프리팹은 `Assets/Prefabs/` 아래에 분류별 폴더를 만들어 둔다. (예 : `Assets/Prefabs/Stage/`)
- 프리팹 파일 이름에는 `PFB_` 접두사를 붙인다. (예 : `PFB_Ground.prefab`)
