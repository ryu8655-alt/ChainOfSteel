using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 効果音の再生と管理を行うクラス
/// </summary>
public class SEManager : MonoBehaviour
{
    [SerializeField,Header("SEのAudioSource")]
    private AudioSource _seAudioSource;

    [SerializeField, Header("SEデータList")]
    List<SESoundDatas> _seSoundDatas;

    [SerializeField,Header("SEマスター音量")]
    private float _seMasterVolume = 1.0f;

    public void PlaySE(string seName)
    {
        //Listの中から指定されたデータを取得する
        SESoundDatas data = _seSoundDatas.Find(data => data._seName == seName);
        
        //該当するデータがあるかを確認する
        if(data == null)
        {
            Debug.LogWarning($"SE名 \"{seName}\" が見つかりませんでした。");
            return;
        }

        //AudioSourceの音量設定
        _seAudioSource.volume = data.volume * _seMasterVolume;

        //AudioSourceの再生(一度だけ再生をする)
        _seAudioSource.PlayOneShot(data._audioClip);
    }


    [System.Serializable]
    public class SESoundDatas
    {

        [Header("SE名(ラベル)")]
        public string _seName;
        [Header("SE音源")]
        public AudioClip _audioClip;
        [Header("SE個別音量")]
        [Range(0,1)]
        public float volume = 1.0f;
    }
}
