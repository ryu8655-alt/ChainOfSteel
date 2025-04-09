
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterSlideIn _characterSlideIn;
    public FaceModeHandler _faceModeHandler;





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
       
        if (_faceModeHandler != null)
        {
            _faceModeHandler.StartSwapping();
        }
    }
}
