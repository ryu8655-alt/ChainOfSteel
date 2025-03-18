using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̑��쐧����s��
//3��18���@�쐬
//�v���C���[�̓���(�J�����̌����𒆐S�ɑO�i�E��ށA���E�ւ̈ړ�)�̋@�\������



public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;//Rigidbody�R���|�[�l���g

    [SerializeField,Header("�v���C���[�ړ����x")] 
    private float _moveSpeed = 5.0f;//�v���C���[�̈ړ����x

    private float _inputHorizontal;//���������̓��͒l
    private float _inputVertical;//���������̓��͒l

    private Vector3 _cameraForward;//�J�����̑O����
    private Vector3 _moveForward;//�v���C���[�̑O����


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
        //�J�����̑O�������擾
        _cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //�ړ��������擾
        _moveForward = _cameraForward * _inputVertical + Camera.main.transform.right * _inputHorizontal;

        //�ړ����x��K�p���āA�v���C���[���ړ�������
        _rigidbody.velocity = _moveForward * _moveSpeed + new Vector3(0, _rigidbody.velocity.y, 0);

        //�ړ��������[���łȂ���΁A�v���C���[�̈ړ������ɕύX����
        if(_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }
    }
}
