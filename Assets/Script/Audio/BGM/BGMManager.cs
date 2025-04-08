using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField,Header("BGMのAudioSource")]
    private AudioSource _bgmAudioSource;

    [SerializeField,Header("再生するBGM")]
    private AudioClip _bgmAudioClip;

    [SerializeField,Header("BGMの音量"),Range(0.0f,1.0f)]
    private float _bgmVolume = 1.0f;

    [SerializeField,Header("BGMのマスター音量"), Range(0.0f, 1.0f)]   
    private float _masterVolume = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        if(_bgmAudioSource==null || _bgmAudioClip == null)
        {
            Debug.LogWarning("AudioSourceまたはBGMが設定されていません。");
            return;
        }

        PlayBGM();


    }


    private void PlayBGM()
    {
        if(_bgmAudioSource.clip == _bgmAudioClip && _bgmAudioSource.isPlaying)
        {
            // すでにBGMが再生中の場合は何もしない
            return;
        }

        _bgmAudioSource.clip = _bgmAudioClip;
        _bgmAudioSource.volume = _bgmVolume * _masterVolume;
        _bgmAudioSource.Play();

    }

}
