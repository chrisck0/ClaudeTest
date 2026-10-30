# Github PR 작성 규칙

> Github PR를 작성할 때의 규칙.
>
> PR 작성 양식은 `@Docs\Template\PRTemplate.md` 를 참고.
>
> 해당 문서는 각 섹션에 대한 작성 규칙을 정의한다.

## 1. Title

- 맨 앞에 Commit 메시지 타입을 단다. 타입 목록은 `Docs\Git\CommitConvention.md`의 `Commit 메시지`를 따른다.
- 타입은 `7. 기타`의 Label과 독립적으로 선택한다.
- 타입을 제외한 제목을 20자 이내로 적는다.
- 상세한 키워드가 아닌 '기능' 단위로 적는다.
- 예시 :
    ```markdown
    - [Feat] 플레이어 이동 구현
    - [Feat] 몬스터 피격 판정 구현
    - [Feat] Weapon 베이스 클래스 생성
    ```

## 2. 무엇을 했는가

- 어떤 작업을 했는지 정리하여 기재한다.
- 리스트로 작성하며, 불필요한 표현을 제거해 간결하게 작성한다.
- 예시 :
    ```markdown
    ## 무엇을 했는가

    - 플레이어와 몬스터간 공격/피격 판정 구현
    - `DamageInfo` 구조체 생성
    - `IDamageable` 인터페이스의 `TakeDamage(DamageInfo info)`를 통해 공격/피격 판정 구현
    ```

## 3. 왜 했는가

- 작업을 한 목적과 해당 방식을 선택한 이유를 작성한다.
- 리스트로 작성하며, 불필요한 표현을 제거해 간결하게 작성한다.
- 예시 :
    ```markdown
    ## 왜 했는가

    - 플레이어와 몬스터간 공격 판정 시 동일한 `IDamageable` 인터페이스를 상속받아 결합도를 낮추기 위함
    - `DamageInfo` 구조체가 데미지를 주는 객체로부터 받는 객체로 전달되어 여러 데이터를 하나의 구조체로 관리
    ```

## 4. 확인사항

- PR을 올리기 전 체크리스트가 충족되었는지 확인하기 위한 목적으로 작성한다.
- PR과 연관된 이슈의 `5. 완료조건 (DoD)` 체크리스트를 그대로 적으며, 체크리스트를 통과하는지를 확인한다. 통과한다면 [x]로 표시한다.
- 예시 :
    ```markdown
    ## 확인사항

    - [x] `PlayerController` 객체와 `MonsterController` 객체가 `IDamageable` 인터페이스를 통해서만 데미지 판정을 주고받는다.
    - [x] `IDamageable.TakeDamage(DamageInfo info)` 메서드를 통해 공격을 시도한 객체에서 공격을 받는 객체로 `DamageInfo` 구조체가 전달된다.
    - [x] 공격을 받는 객체에서 `DamageInfo` 구조체의 정보를 받아 로그 출력에 성공했다.
    - [x] 유니티 에디터에서 컴파일 에러 및 Error, Warning 로그가 발생하지 않는다.
    ```

## 5. 참고사항

- 변경되었거나 해당 이슈 혹은 PR에서 중요한 파일의 경로를 기재한다.
- 리스트로 작성한다.
- 예시 : 
    ```markdown
    ## 참고사항

    - `Assets/Scripts/PlayerController.cs` 수정
    - `Assets/Scripts/Core/IDamageable.cs` 수정
    - `Assets/Scripts/Core/DamageInfo.cs` 생성
    - `Assets/Prefabs/Player/PFB_Player.prefab` 수정
    ```

## 6. 특이사항

- 아래의 사항에 해당되지 않으면 이 섹션은 기재하지 않는다.
  1. `Github Issues`에 등록된 Issue와 연관되어 있는 경우.
  2. 다른 리뷰어가 꼭 알아야 하는 전달 사항, 주의사항이 있는 경우.
- `Github Issues`에 등록된 Issue를 언급하는 경우, 태그를 걸어둔다.

## 7. 기타

### Label

- Label은 아래 항목 중 하나를 선택해 할당한다. 해당되는 Label이 등록되어 있지 않은 경우, Label을 새로 등록하고 할당한다.
  - Fix : 버그를 수정.
  - Docs : 문서 관련 작업을 수행.
  - Feature : 새로운 기능을 추가.
  - Improvement : 기존 기능을 개선하거나 보수하는 작업.
  - Art : 그래픽 및 에셋 제작.
  - Refactor : 기능에 변화를 주지 않는 코드 개선.
  - Chore : 기타 유지보수 작업, 설정 및 패키지 정리.