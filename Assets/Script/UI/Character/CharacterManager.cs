
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterSlideIn _characterSlideIn;
    public FaceModeHandler _faceModeHandler;

    [SerializeField,Header("メッセージウィンドウUI")]
    private GameObject _messageWindowUI;

    [SerializeField, Header("MessageWindowHandler")]
    private MessageWindowHandler _messageWindowHandler;





    // Start is called before the first frame update
    void Start()
    {
        if( _characterSlideIn != null)
        {
            _characterSlideIn._onSlideInFinished += OnSlideInFinished;
            _characterSlideIn.StartSlideIn();
            
           
        }
        
    }

    private void OnSlideInFinished()
    {

        _messageWindowUI.SetActive(true);

       _messageWindowHandler.ShowIntialLine();
        _messageWindowHandler.StartRandomLines(10f);

        //if (_faceModeHandler != null)
        //{
        //    _faceModeHandler.StartSwapping();
        //}

        //if(_messageWindowUI != null)
        //{
        //    _messageWindowUI.SetActive(true);
        //    Debug.Log("メッセージウィンドウを表示しました");
        //}

    }
}
