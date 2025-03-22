using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


//ボタンクリック時にボタンのTextMeshProの位置を上下に動かす

public class ButtonTextShift : MonoBehaviour
{
    [SerializeField, Header("対象のボタン")]
    private Button _targetButton;

    [SerializeField, Header("TextMeshProのオブジェクト")]
    private TextMeshProUGUI _buttonText;

    [Header("padingの値")]
    [SerializeField,Header("押下前のテキスト位置")]
    private Vector4 _beforePadding = new Vector4(0, -4, 0, 4);//Vector4の内訳(Left・Top・Right・Bottom)の順番

    [SerializeField, Header("押下後のテキスト位置")]
    private Vector4 _afterPadding = new Vector4(0, 2, 0, -2);//Vector4の内訳(Left・Top・Right・Bottom)の順番



    // Start is called before the first frame update
    void Start()
    {
        //初期状態
        _buttonText.margin = _beforePadding;

        //EventTriggerを追加
        EventTrigger trigger = _targetButton.gameObject.AddComponent<EventTrigger>();

        //PointerDownイベントを登録
        var downEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        downEntry.callback.AddListener((data) =>//処理設定　クリックした瞬間に押下時のpaddingに変更
        {
            _buttonText.margin = _afterPadding;
        });
        trigger.triggers.Add(downEntry);//Buttonにこのイベント設定を追加

        //PointerUpイベント
        var upEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        upEntry.callback.AddListener((data) =>
        {
            _buttonText.margin = _beforePadding;
        });
        trigger.triggers.Add(upEntry);


    }
}
