using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPS�J��������
//�}�E�X����ɂ��J�����̐����Ɛ��������̉�]�������s��
//�܂��J�����̓v���C���[�̈ʒu�ɍ��킹��

//�܂���قǉ�]�p�x�ɂ��Ă͐�����������@��������l�ɂ��Ă̓C���X�y�N�^�[����ݒ�ł���悤�ɂ���

public class CameraController : MonoBehaviour
{
    [SerializeField,Header("�Ǐ]����v���C���[�I�u�W�F�N�g")]
    private GameObject _player;

    [SerializeField, Header("�J�����̉�]���x")]
    private float _rotateSpeed = 100.0f;

    private Vector3 _playerPosition;//�v���C���[�̍��W

    private float _inputMouseX;//�}�E�X��X���̈ړ���
    private float _inputMouseY;//�}�E�X��Y���̈ړ���


    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�����̈ʒu���v���C���[�̈ʒu�ɍ��킹��
        transform.position += _player.transform.position - _playerPosition;
        _playerPosition = _player.transform.position;

        //�}�E�X��X���EY���̓��͂��擾
        _inputMouseX = Input.GetAxis("Mouse X");
        _inputMouseY = Input.GetAxis("Mouse Y");

        //�J�����̉�]����
        transform.RotateAround(_player.transform.position, Vector3.up, _inputMouseX * _rotateSpeed * Time.deltaTime);
        transform.RotateAround(_player.transform.position, transform.right, -_inputMouseY * _rotateSpeed * Time.deltaTime);


    }
}
