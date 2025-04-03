using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    [SerializeField, Header("遷移先のシーン名")]
    private string _sceneName;

    private Button _button;

    private void Awake()
    {
        //Buttonコンポーネントを取得
        _button = GetComponent<Button>();
        //ボタンにクリックイベントを追加
        _button.onClick.AddListener(TryLoadScene);
    }

    ///<summary>
    ///実際に遷移先のシーンの確認を行い遷移するメソッド
    ///</summary>
    private void TryLoadScene()
    {
        if (string.IsNullOrEmpty(_sceneName))
        {
            Debug.LogWarning($"[{gameObject.name}]シーン名が設定されていません");
            return;
        }

        //シーン名がBuildSettingsに登録されているか確認
        if (!IsSceneInBuildSettings(_sceneName))
        {
            Debug.LogWarning($"[{gameObject.name}]対象シーンがBuild Settingsに追加されていません。");
            return;       
        }

        SceneManager.LoadScene(_sceneName);

    }


    /// <summary>
    /// 遷移先に指定したシーンがBuildSettingsに登録されているか確認する
    /// </summary>
    private bool IsSceneInBuildSettings(string targetSceneName)
    {
        //BuildSettingsに登録されているシーンの数を取得
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; ++i)
        {
            //BuildSettingsに登録されているシーンのパスを取得
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            //シーン名を取得
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            //指定したシーン名と一致するか確認
            if (sceneName == targetSceneName)
            {
                return true;
            }
        }
        return false;
    }







}
