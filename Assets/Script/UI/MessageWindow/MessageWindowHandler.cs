using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//データ構造(セリフ・キャラ表情・ボイスデータ
[System.Serializable]
public class DialogueData
{
    public string text; //セリフ
    public string exprressionName; //キャラ表情
    public AudioClip voiceClip; //ボイスデータ
}



public class MessageWindowHandler : MonoBehaviour
{
    [SerializeField,Header("FaceModeHandler")]
    private FaceModeHandler _faceModeHandler;

    [SerializeField, Header("TextMeshPro")]
    private TextMeshProUGUI _meshProUGUI;

    [SerializeField, Header("AudioSource")]
    private AudioSource _voicePlayer;

    [SerializeField,Header("メッセージウィンドウUI")]
    private GameObject _messageWindow;


    [SerializeField,Header("シーン遷移時にしゃべるセリフデータ")]
    private　DialogueData[] _dialogueData;

    [SerializeField, Header("シーン放置時にしゃべるセリフデータ")]
    private List<DialogueData> _idleDialogueData;

    private Coroutine _idleeLineCoroutine;


    public void ShowIntialLine()
    {
        var selectedLine = _dialogueData[Random.Range(0, _dialogueData.Length)];
        DisplayLine(selectedLine);
    }

    public void StartRandomLines(float interval = 10f)
    {
        if (_idleeLineCoroutine != null) StopCoroutine(_idleeLineCoroutine);
        _idleeLineCoroutine = StartCoroutine(IdleLineRoutine(interval));


    }
        public IEnumerator IdleLineRoutine(float interval)
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            var line = _idleDialogueData[Random.Range(0, _idleDialogueData.Count)];
            DisplayLine(line);
        }
    }


    private void DisplayLine(DialogueData entry)
    {
        _messageWindow.SetActive(true);
        _meshProUGUI.text = entry.text;
        _faceModeHandler.setExpreesion(entry.exprressionName);
        if(entry.voiceClip != null)
        {
            _voicePlayer.clip = entry.voiceClip;
            _voicePlayer.Play();
        }

    }

}
