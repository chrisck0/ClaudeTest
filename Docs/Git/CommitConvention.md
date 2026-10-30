# CommitConvention

## Commit 단위
- 각 커밋을 이슈 단위로 만들어서 최소한 이슈당 하나 Commit을 한다.
- 아래 Commit Type의 여러 종류를 한 번에 Commit하지 않고, 한 Type마다 나눠서 Commit한다.
- [Fix]는 사소한 코드 수정에는 사용하지 않고 버그 수정에만 사용한다.

## Commit 메시지
커밋 메시지는 다음과 같이 작성한다.

| 타입 (Type) | 설명 (Description) | 작성 예시 (Example) |
| :--- | :--- | :--- |
| **[Feat]** | 새로운 기능 추가 | `[Feat] 플레이어 더블 점프 기능 추가` |
| **[Fix]** | 버그 수정 | `[Fix] 충돌 판정 오류 수정` |
| **[Docs]** | 문서 수정 | `[Docs] README 설치 방법 업데이트` |
| **[Style]** | 기능 변경 없는 코드 정리 | `[Style] 들여쓰기 및 공백 정리` |
| **[Refactor]** | 기능 변경 없는 구조 개선 | `[Refactor] 아이템 관리 구조 개선` |
| **[Chore]** | 빌드, 설정, 패키지 등 작업 | `[Chore] .gitignore에 빌드 산출물 항목 추가` |

## Commit 이후 Push
- Commit이 완료되었다면 스스로 Push할 수 없다.  
- 반드시 사용자에게 Commit을 Push할지 물어보고, 사용자에게 승인을 받았다면 Push한다.

