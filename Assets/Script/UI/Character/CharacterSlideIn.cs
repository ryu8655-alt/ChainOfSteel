using System;
using UnityEngine;

/// <summary>
/// シーン遷移した時に、キャラクター画像がスライドしてくる演出管理を行うクラス
/// </summary>


public class CharacterSlideIn : MonoBehaviour
{
    

    [SerializeField, Header("スライドイン開始位置")]
    private Vector2 _startPosition = new Vector2(1500f, -220f);

    [SerializeField, Header("スライドイン終了位置")]
    private Vector2 _targetPosition = new Vector2(570f, -220f);

    [SerializeField, Header("演出時間"), Range(0.0f, 5.0f)]
    private float _slideTime = 1.0f;

    //演出経過時間カウント変数
    private float _elapsedTime = 0.0f;

    //スライド演出を行ったかの確認フラグ
    private bool _isSlide = false;

    private RectTransform _targetRectTransform;


    public Action _onSlideInFinished; //スライドイン演出終了時に呼び出すデリゲート



    public void StartSlideIn()
    {
        if(_targetRectTransform == null)
        {
            _targetRectTransform = GetComponent<RectTransform>();
        }

        //スライド演出を行うための初期化
        _elapsedTime = 0.0f;
        _isSlide = true;


    }



    // Update is called once per frame
    void Update()
    {
        if (!_isSlide) return;

        //スライドイン演出を行う
        SlideIn();

    }


    private void SlideIn()
    {
        _elapsedTime += Time.deltaTime;
        float time = Mathf.Clamp01(_elapsedTime / _slideTime);

        //線形保管を使用し、開始位置から終了位置まで移動
        _targetRectTransform.anchoredPosition = Vector2.Lerp(_startPosition, _targetPosition, time);

        //演出時間が経過したら、スライドフラグをOFF
        if (time >= 1.0f)
        {
            _isSlide = false;
            _onSlideInFinished?.Invoke(); //スライドイン演出終了時に呼び出すデリゲートを実行
        }
    }



}
