using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 
/// </summary>
[System.Serializable]
public class  ExprssionEntry
{
    public string _faceName; //表情名
    public Sprite _spliet; //表情に対応するスプライト
}




/// <summary>
/// キャラクターの表情スクリプトを登録し、設定時間ごとに切り替える
/// </summary>
public class FaceModeHandler: MonoBehaviour
{

    [SerializeField, Header("キャラクター画像"), Tooltip("表情を切り替えるキャラクター画像")]
    public Image _CharacterImage; //キャラクター画像


    [SerializeField, Header("表情切り替え時間"),Range(0f,5f)]
    private float _changeTime = 1.0f;

    [SerializeField, Header("表情リスト")]
    private List<ExprssionEntry> _expressionList = new List<ExprssionEntry>();

    private Dictionary<string, Sprite> _expressionDictionary;

    private int _currentIndex = 0; //現在の表情インデックス
    private float _elapsedTime = 0.0f; //経過時間
    private bool _isActive = false; //表情切り替えフラグ


    private void Awake()
    {
        //表情リストを辞書に変換 =　アクセスの高速化を行うため
        _expressionDictionary = new Dictionary<string, Sprite>();
        foreach (var entry in _expressionList)
        {
            if (!_expressionDictionary.ContainsKey(entry._faceName))
            {
                _expressionDictionary.Add(entry._faceName, entry._spliet);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //表情切り替えフラグがfalseの場合、表情リストデータ数が0の場合は何もしない
        if(!_isActive || _expressionList.Count == 0) return;


        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _changeTime)
        {
            //表情を切り替える
            ChangeExpression();
        }


        
    }


    /// <summary>
    /// 表情を順に切り替える処理を実施
    /// </summary>
    private void ChangeExpression()
    {

       //表情を切り替える
        _currentIndex = (_currentIndex + 1) % _expressionList.Count;
        _CharacterImage.sprite = _expressionList[_currentIndex]._spliet;

        //経過時間をリセット
        _elapsedTime = 0.0f;
    }

    
    public void StartSwapping()
    {
        Debug.Log("StartSwapping");
        _isActive = true;
    }

    public void StopSwapping()
    {
        _isActive = false;
    }

    ///外部から表情を指定して切り替えるメソッド

    public void setExpreesion(string expressionName)
    {
        if (_expressionDictionary.TryGetValue(expressionName, out Sprite sprite))
        {
            _CharacterImage.sprite = sprite;
            StopSwapping();//表情切り替えを停止
        }
        else
        {
            Debug.LogError($"表情名「{expressionName}」は登録されていません。");
        }
    }

    public void ResetExpression()
    {
     
        _currentIndex = 0; //表情インデックスをリセット
        if(_expressionList.Count > 0)
        {
            _CharacterImage.sprite = _expressionList[_currentIndex]._spliet; //初期表情に戻す
        }


    }



}
