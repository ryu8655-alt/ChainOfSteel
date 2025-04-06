using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// BGMの再生と管理を行うクラス
/// </summary>

//メモ
//既存のBGMManagerと干渉するので一時的にファイル名をbgmManagerにしてる
//後でBGMManagerに戻す
public class BGMManager : MonoBehaviour
{
    [SerializeField, Header("BGMのAudioSource")]
    private AudioSource _bgmAudioSource;

    [SerializeField,Header("再生するBGM")]
    private AudioClip _bgmAudioClip;

    [SerializeField, Header("BGMマスター音量"),Range(0f,1.0f)]
    private float _bgmMasterVolume = 1.0f;

    [SerializeField,Header("BGM音量"), Range(0f, 1.0f)]
    private float _bgmVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        //AudioSourceの設定・再生するBGMの設定がされているのか確認
        if(_bgmAudioSource == null || _bgmAudioClip == null)
        {
            Debug.LogWarning("AudioSourceまたはAudioClipが設定されていません。");
            return;
        }

        //BGMの再生処理
        PlayBGM();
        
    }

    private void PlayBGM()
    {
        if (_bgmAudioSource.clip == _bgmAudioClip && _bgmAudioSource.isPlaying)
        {
            //同じBGMが再生中の場合は何もしない
            return;
        }

        _bgmAudioSource.clip = _bgmAudioClip;
        _bgmAudioSource.volume = _bgmMasterVolume * _bgmVolume;

        _bgmAudioSource.Play();

    }

}
