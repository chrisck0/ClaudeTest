---
name: github-issue
description: Github Issue 등록 절차. 개발/버그 수정 명령을 받아 Issue 등록을 권유하거나, 사용자가 Issue 작성을 요청할 때 사용한다.
---

# Github Issue 등록

> 워크플로우 `2. Github Issue` 단계를 수행하는 스킬.
>
> 이 스킬은 **절차와 멘트 규격**만 정의한다. 섹션별 작성 규칙은 아래 원본 문서를 읽고 따른다. (규칙의 단일출처 유지)

## 참조 문서

| 필요한 시점 | 문서 | 읽을 섹션 |
| --- | --- | --- |
| 권유 여부 판단 | `Docs\Claude\WorkflowRules.md` | `2. Github Issue` |
| 본문 양식 | `Docs\Template\IssueTemplate.md` | 전체 |
| 섹션별 작성 | `Docs\Documentation\GithubIssueRules.md` | 작성 중인 섹션 (`1. Title` ~ `6. 특이사항`) |
| Label 선택 | `Docs\Documentation\GithubIssueRules.md` | `7. 기타` > `Label` |

---

## 절차

1. **권유** : `WorkflowRules.md`의 기준으로 등록 필요 여부를 판단하고, [권유 멘트](#1-권유-멘트)로 권유한다.
   - 사용자가 Issue 생성을 하지 않도록 명시한 경우(예 : 작업지시서) 이 스킬을 중단한다.
   - 거절 시 Issue 없이 `3. 브리핑`으로 넘어간다.
2. **배경 / 목적 확인** : [질문 멘트](#2-배경--목적-질문-멘트)로 사용자에게 질문한다. 답을 받지 못하면 작성을 거부한다.
3. **초안 작성** : 참조 문서를 읽고 양식에 맞춰 초안을 작성한다.
4. **승인** : [승인 멘트](#3-작성-전-승인-멘트)로 초안을 보여주고 승인을 받는다. 수정 요청 시 3번으로 돌아간다.
5. **등록** : `gh issue create`로 등록한다. Label이 없으면 `gh label create`로 먼저 생성한다.
6. **안내** : [완료 멘트](#4-등록-완료-멘트)로 Issue 번호를 알린다.
   - Assignees 지정은 이슈에 **착수할 때** 수행한다. (`gh issue edit <번호> --add-assignee @me`)

---

## 멘트 규격

- 각 멘트는 아래 형식만 사용하고, 형식 밖의 설명을 덧붙이지 않는다.
- `[ ]` 안은 한 줄로 작성한다.

### 1. 권유 멘트

```markdown
**Issue 등록 권유**
- 유형 : [개발 / 버그 수정]
- 사유 : [권장 이유 한 줄]
- 예상 Label : [Label]

Issue를 작성할까요?
```

### 2. 배경 / 목적 질문 멘트

```markdown
Issue의 `배경 / 목적`을 알려주세요.
- 왜 이 작업이 필요한가요?
- 이 작업으로 무엇을 해결하려 하나요?
```

### 3. 작성 전 승인 멘트

```markdown
**Issue 초안**
- Label : [Label]

(IssueTemplate 양식의 본문 전체)

이대로 등록할까요?
```

### 4. 등록 완료 멘트

```markdown
Issue #[번호] 등록 완료 : [URL]
```
