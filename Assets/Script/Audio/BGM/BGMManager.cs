using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField,Header("再生するBGM")]
    private AudioClip _bgmClip;

    [Header("音量(Optionで調整予定)")]
    [Range(0, 1)]
    [SerializeField] private float _volume = 1.0f;

    private AudioSource _audioSource;

    private void Awake()
    {
        //AudioSource設定
        //AudioSourceコンポーネントを取得
        _audioSource = gameObject.AddComponent<AudioSource>();
        //AudioClipを設定
        _audioSource.clip = _bgmClip;
        //ループ再生を設定
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;

        //音量を設定
        _audioSource.volume = _volume;

    }
    // Start is called before the first frame update
    void Start()
    {

        if(_audioSource.clip != null)
        {
            _audioSource.Play();
        }
    }

    //オプション設定から呼び出すメソッド
    public void SetVolume( float volume)
    {
        _audioSource.volume = volume;
    }


}
