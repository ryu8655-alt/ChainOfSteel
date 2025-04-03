using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTextShift : MonoBehaviour
{
    [SerializeField, Header("対象のボタン")]
    private Button _button;

    [SerializeField, Header("ボタンのテキスト")]
    private TextMeshProUGUI _buttonText;

    [Header("padingの値")]
    [SerializeField, Header("押下前のテキスト位置")]
    private Vector4 _beforePadding = new Vector4(0, -4, 0, 4);//Vector4の内訳(Left・Top・Right・Bottom)の順番

    [SerializeField, Header("押下後のテキスト位置")]
    private Vector4 _afterPadding = new Vector4(0, 2, 0, -2);//Vector4の内訳(Left・Top・Right・Bottom)の順番


    // Start is called before the first frame update
    void Start()
    {
        //初期状態
        _buttonText.margin = _beforePadding;

        //EventTriggerを追加
        EventTrigger trigger = _button.gameObject.AddComponent<EventTrigger>();

        //PointerDownイベントを追加
        var downEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        downEntry.callback.AddListener((data) =>//処理設定　クリックした瞬間に押下時のpaddingに変更
        {
            _buttonText.margin = _afterPadding;
        });
        trigger.triggers.Add(downEntry);//ButtonにEventTriggerを追加


        //PointerUpイベントを追加
        var upEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        upEntry.callback.AddListener((data) =>//処理設定　クリックを離した瞬間に押下前のpaddingに変更
        {
            _buttonText.margin = _beforePadding;
        });
        trigger.triggers.Add(upEntry);//ButtonにEventTriggerを追加
    }

    // Update is called once per frame
    void Update()
    {

    }
}
