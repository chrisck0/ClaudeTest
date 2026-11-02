using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 스테이지 선택 화면의 버튼 입력을 처리한다.
/// </summary>
public class StageSelectMenu : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";

    [SerializeField] private Button _stage1_1Button;

    private void OnEnable() => BindButtons();
    private void OnDisable() => UnbindButtons();

    private void OnStage1_1Clicked()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    private void BindButtons()
    {
        _stage1_1Button.onClick.AddListener(OnStage1_1Clicked);
    }

    private void UnbindButtons()
    {
        _stage1_1Button.onClick.RemoveListener(OnStage1_1Clicked);
    }
}
