using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの操作制御を行う
//3月18日　作成
//プレイヤーの動き(カメラの向きを中心に前進・後退、左右への移動)の機能を実装



public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;//Rigidbodyコンポーネント

    [SerializeField,Header("プレイヤー移動速度")] 
    private float _moveSpeed = 5.0f;//プレイヤーの移動速度

    private float _inputHorizontal;//水平方向の入力値
    private float _inputVertical;//垂直方向の入力値

    private Vector3 _cameraForward;//カメラの前方向
    private Vector3 _moveForward;//プレイヤーの前方向


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");

    }



    private void FixedUpdate()
    {
        //カメラの前方向を取得
        _cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //移動方向を取得
        _moveForward = _cameraForward * _inputVertical + Camera.main.transform.right * _inputHorizontal;

        //移動速度を適用して、プレイヤーを移動させる
        _rigidbody.velocity = _moveForward * _moveSpeed + new Vector3(0, _rigidbody.velocity.y, 0);

        //移動方向がゼロでなければ、プレイヤーの移動方向に変更する
        if(_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }
    }
}
