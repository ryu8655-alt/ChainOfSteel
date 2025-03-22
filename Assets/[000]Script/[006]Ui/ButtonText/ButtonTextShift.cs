using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


//�{�^���N���b�N���Ƀ{�^����TextMeshPro�̈ʒu���㉺�ɓ�����

public class ButtonTextShift : MonoBehaviour
{
    [SerializeField, Header("�Ώۂ̃{�^��")]
    private Button _targetButton;

    [SerializeField, Header("TextMeshPro�̃I�u�W�F�N�g")]
    private TextMeshProUGUI _buttonText;

    [Header("pading�̒l")]
    [SerializeField,Header("�����O�̃e�L�X�g�ʒu")]
    private Vector4 _beforePadding = new Vector4(0, -4, 0, 4);//Vector4�̓���(Left�ETop�ERight�EBottom)�̏���

    [SerializeField, Header("������̃e�L�X�g�ʒu")]
    private Vector4 _afterPadding = new Vector4(0, 2, 0, -2);//Vector4�̓���(Left�ETop�ERight�EBottom)�̏���



    // Start is called before the first frame update
    void Start()
    {
        //�������
        _buttonText.margin = _beforePadding;

        //EventTrigger��ǉ�
        EventTrigger trigger = _targetButton.gameObject.AddComponent<EventTrigger>();

        //PointerDown�C�x���g��o�^
        var downEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        downEntry.callback.AddListener((data) =>//�����ݒ�@�N���b�N�����u�Ԃɉ�������padding�ɕύX
        {
            _buttonText.margin = _afterPadding;
        });
        trigger.triggers.Add(downEntry);//Button�ɂ��̃C�x���g�ݒ��ǉ�

        //PointerUp�C�x���g
        var upEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        upEntry.callback.AddListener((data) =>
        {
            _buttonText.margin = _beforePadding;
        });
        trigger.triggers.Add(upEntry);


    }
}
