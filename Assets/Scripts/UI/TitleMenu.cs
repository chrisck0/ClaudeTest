using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 타이틀 화면의 메뉴 버튼 입력을 처리한다.
/// </summary>
public class TitleMenu : MonoBehaviour
{
    private const string STAGE_SELECT_SCENE = "StageSelectScene";

    [SerializeField] private Button _startButton;

    private void OnEnable() => BindButtons();
    private void OnDisable() => UnbindButtons();

    private void OnStartClicked()
    {
        SceneManager.LoadScene(STAGE_SELECT_SCENE);
    }

    private void BindButtons()
    {
        _startButton.onClick.AddListener(OnStartClicked);
    }

    private void UnbindButtons()
    {
        _startButton.onClick.RemoveListener(OnStartClicked);
    }
}
