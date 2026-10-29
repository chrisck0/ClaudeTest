# Code Convention

## 1. 변수명
기본 C# 컨벤션을 기반으로 하고 아래를 따른다.

| 대상 | 표기법 | 예시 |
| --- | ------ | ---- |
| 지역 변수 | camelCase | `playerLevel` |
| 클래스·형식 이름 | PascalCase | `PlayerController` |
| public 멤버 | PascalCase | `MaxHealth` |
| private 멤버 | _camelCase | `_currentHealth` |
| 상수 | 대문자, 단어 사이 밑줄 | `MAX_LEVEL`|
| 인터페이스 | I + PascalCase | `IInteractable` |


## 2. 주석
- 코드를 읽었을 때 한 눈에 이해하기 쉬운 경우에는 주석을 작성하지 않는다.
- 주석 끝은 명사형으로 마친다.
- 사용하지 않는 코드는 주석 처리하지 않고 삭제한다.

### 일반 주석
코드를 읽었을 때 이해하기 어렵거나 버그 회피를 위한 코드에는 `//`를 사용하여 주석을 단다.

#### 예시
```csharp
float padding = 0.5f / _textureSize; // Mipmap(texture) bleeding(Texture atlas 때문에 경계면에 작은 점들이 발생하는 것)을 막기 위해 padding을 넣음
```

### XML 주석
`public` 멤버에는 반드시 XML 주석 (`///`)를 사용하여 주석을 단다.

#### 예시
```csharp
/// <summary>
/// 오브젝트 풀로 Chunk를 관리하고, 타겟 위치에 따라 Chunk를 불러오며 활성화/비활성화시킨다.
/// </summary>
public class ChunkManager : MonoBehaviour
{
    //...

    /// <summary>
    /// 생성할 Chunk의 정보를 저장
    /// </summary>
    /// <param name="chunkIndex"> 월드맵 기준 Chunk의 번호 </param>
    /// <param name="worldMap"> Chunk 정보가 저장된 월드맵 </param>
    /// <param name="material"> Chunk 전체의 material </param>
    /// <param name="textureSize"> Texture 한 변의 픽셀 수 </param>
    /// <param name="atlasSize"> Texture atlas의 한 변 크기 </param>
    public void SetChunkData(int chunkIndex, int[,] worldMap, Material material, float textureSize, float atlasSize)
    {
        //...
    }
}
```

### 주석 태그
`TODO`, `FIXME`, `BUG`를 사용하여 아래 상황에 부합한다면 주석 앞에 태그를 붙인다.

| 주석 태그 | 설명 |
| --- | --- |
| TODO | 앞으로 해야 할 일 |
| FIXME | 앞으로 수정되어야 할 일 |
| BUG | 버그가 발생한 위치 |

#### 예시
```csharp
// TODO: 외부에서 사용할 수 있는 DB의 ID에 접근하는 method 구현
// FIXME: 하드 코딩 개선
```

## 3. 코드 스타일

- Unity 이벤트 함수에는 아래 예시와 같이 람다 식을 사용하여 한 줄로 작성한다.
- 접근제한자를 생략하지 않고 반드시 적는다.
- 접근제한자는 기본적으로 `private`으로 두며, 필요하면 `public` 또는 `protected` 등 다른 접근제한자를 사용한다.
- InputActionReference, Button, Delegate 등은 `BindXxx`, `UnbindXxx`처럼 필요한 단위를 묶어서 적는다.
- 인스펙터에 노출시키기 위해서 `private` 또는 `protected`를 `public`으로 변경하지 않는다. `privated`, `protected` 멤버를 인스펙터에 보이게 만들고 싶다면 접근제한자를 변경하지 않고 `[SerializeField]`를 사용한다.

#### 예시
```csharp
public class TouchMobile : MonoBehaviour
{
    [SerializeField] private InputActionReference _pressInput;
    
    private Player _player;

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputActions();
    private void OnDisable() => UnbindInputActions();

    private void OnTouch(InputAction.CallbackContext context)
    {
        Debug.Log("OnTouch");
    }

    private void OnUntouched(InputAction.CallbackContext context)
    {
        Debug.Log("OnUntouched");
    }

    private void CacheComponents()
    {
        _player = GetComponent<Player>();
    }

    private void BindInputActions()
    {
        _pressInput.action.Enable();
        _pressInput.action.performed += OnTouch;
        _pressInput.action.canceled += OnUntouched;
    }

    private void UnbindInputActions()
    {
        _pressInput.action.Disable();
        _pressInput.action.performed -= OnTouch;
        _pressInput.action.canceled -= OnUntouched;
    }
}
```
