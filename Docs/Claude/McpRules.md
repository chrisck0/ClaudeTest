# MCP 사용 규칙

> Unity MCP(ai-game-developer, com.ivanmurzak.unity.mcp) 연결 환경에서 Claude Code가 지켜야 하는 규칙

---

## 수정 금지 파일

> 아래 파일은 Claude가 어떤 경우에도 생성, 수정, 삭제하지 않는다. 변경이 필요하면 사용자에게 보고만 한다.

### MCP 연결 파일

| 경로 | 역할 | 수정 시 문제 |
|---|---|---|
| `.mcp.json` | Claude Code → MCP 서버 접속 주소 | MCP 연결 끊김 |
| `UserSettings/AI-Game-Developer-Config.json` | Unity 측 MCP 플러그인 설정 (토큰 포함) | 서버-플러그인 불일치, 토큰 노출 |
| `Assets/Plugins/NuGet/**` | MCP 통신 라이브러리(DLL) | 컴파일 오류, 플러그인 동작 불가 |
| `Packages/manifest.json` | 패키지 목록 (MCP 패키지 포함) | 패키지 제거·버전 변경 |
| `Packages/packages-lock.json` | 패키지 의존성 잠금 | 의존성 불일치 |

---

## MCP 사용 원칙

- 씬(`.unity`)·프리팹(`.prefab`)은 텍스트로 직접 수정하지 않고 MCP 도구로만 수정한다. (에디터가 열어 둔 파일을 외부에서 고치면 덮어쓰기 충돌이 난다)
- 패키지 추가·제거는 Claude가 하지 않는다. 사용자가 Package Manager에서 직접 한다.
- `AI-Game-Developer-Config.json`의 `token` 값은 읽거나 출력하지 않는다.
