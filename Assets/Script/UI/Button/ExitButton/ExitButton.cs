using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// ExitButttonが押されたときにアプリケーションを終了する
/// </summary>
public class ExitButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        //Buttonコンポーネントを取得
        _button = GetComponent<Button>();

        //ボタンにクリックイベントを追加
        _button.onClick.AddListener(ExitGame);
    }

    /// <summary>
    /// ゲーム終了処理(エディタ使用時も終了するように実装)
    /// </summary>
    private void ExitGame()
    {
        //エディタ使用時はPlayモードを終了
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
