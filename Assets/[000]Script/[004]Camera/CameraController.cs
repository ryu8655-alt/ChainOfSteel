using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPSカメラ制御
//マウス操作によるカメラの水平と垂直方向の回転処理を行う
//またカメラはプレイヤーの位置に合わせる

//また後ほど回転角度については制限をかける　上限下限値についてはインスペクターから設定できるようにする

public class CameraController : MonoBehaviour
{
    [SerializeField,Header("追従するプレイヤーオブジェクト")]
    private GameObject _player;

    [SerializeField, Header("カメラの回転速度")]
    private float _rotateSpeed = 100.0f;

    private Vector3 _playerPosition;//プレイヤーの座標

    private float _inputMouseX;//マウスのX軸の移動量
    private float _inputMouseY;//マウスのY軸の移動量


    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置をプレイヤーの位置に合わせる
        transform.position += _player.transform.position - _playerPosition;
        _playerPosition = _player.transform.position;

        //マウスのX軸・Y軸の入力を取得
        _inputMouseX = Input.GetAxis("Mouse X");
        _inputMouseY = Input.GetAxis("Mouse Y");

        //カメラの回転処理
        transform.RotateAround(_player.transform.position, Vector3.up, _inputMouseX * _rotateSpeed * Time.deltaTime);
        transform.RotateAround(_player.transform.position, transform.right, -_inputMouseY * _rotateSpeed * Time.deltaTime);


    }
}
