using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Chara
{
    Player = 0,
    Enemy = 1,
}

public class CharacterScript : MonoBehaviour
{
    [Header("�L�����N�^�[")]
    [SerializeField, Tooltip("�N���X�����Ă�I�u�W�F�N�g�̃L����")]
    private Chara _chara;
    [SerializeField, Tooltip("�L�����̃X�s�[�h")]
    private float _charaSpeed = 1;
    [SerializeField, Tooltip("�L�����̃m�b�N�o�b�N�З�")]
    private float _kbDis = 1f;
    [SerializeField, Tooltip("�L�����̃m�b�N�o�b�N����Ă鎞��")]
    private float _kbTime = 1f;

    public bool _isMove = false;

    private void Start()
    {
        if (_kbDis <= 0) { Debug.LogError("�m�b�N�o�b�N�����̒l��ݒ肵�Ă�������"); }
        if (_kbTime <= 0) { Debug.LogError("�m�b�N�o�b�N���Ԃ�ݒ肵�Ă�������"); }
        _isMove = false;
    }

    private void Update()
    {
        if (_isMove) return;

        CharaMove(this.gameObject.transform);
    }

    private void CharaMove(Transform tr)
    {
        if (_chara == Chara.Player)
        {
            tr.Translate(Vector3.right * Time.deltaTime * _charaSpeed);
        }
        else if (_chara == Chara.Enemy)
        {
            tr.Translate(Vector3.left * Time.deltaTime * _charaSpeed);
        }
    }

    public void KnockBack()
    {
        if (_chara == Chara.Player)
        {
            gameObject.transform.DOLocalMove
            (gameObject.transform.position + (gameObject.transform.right * -1) * _kbDis, _kbTime);
            _isMove = true;
        }
        else if (_chara == Chara.Enemy)
        {
            gameObject.transform.DOLocalMove
            (gameObject.transform.position + gameObject.transform.right * _kbDis, _kbTime);
            _isMove = true;
        }
    }

    public void MoveStart()
    {
        if(_isMove)
        {
            _isMove = false;
        }
    }
}
