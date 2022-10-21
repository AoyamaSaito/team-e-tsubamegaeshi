using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

//TODO
//Player��Enemy�����̊Ǘ����s���ƃR�[�h�ʂ������Ȃ邩��
//�K�v�ł���Ε�������

/// <summary>
/// �V�[������Player��Enemy�̈ʒu���Ǘ�����
/// </summary>
public class DistanceManager : MonoBehaviour
{
    [Header("�v���C���[")]
    [SerializeField, Tooltip("�v���C���[�̃v���n�u")]
    private GameObject _playerPrefab;
    [SerializeField, Tooltip("�v���C���[�̃X�s�[�h")]
    private float _playerSpeed = 1;
    [SerializeField, Tooltip("�v���C���[�̏������W")]
    private Transform _playerInitPos;

    [Header("�G")]
    [SerializeField, Tooltip("�G�̃v���n�u")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("�G�̃X�s�[�h")]
    private float _enemySpeed = 1;
    [SerializeField, Tooltip("�G�̏������W")]
    private Transform _enemyInitPos;
    [SerializeField, Tooltip("�m�b�N�o�b�N�̈З�")]
    private float _kbDistance = 1f;
    [SerializeField, Tooltip("�m�b�N�o�b�N����Ă鎞��")]
    private float _kbTime = 1f;

    [Header("�X�e�[�W�ݒ�")]
    [SerializeField, Tooltip("�X�e�[�W�̍ō�")]
    private Transform _start;
    [SerializeField, Tooltip("�X�e�[�W�̍ŉE")]
    private Transform _end;
    [SerializeField, Tooltip("�Î~������`����")]
    private float _stopDistance = 0.05f;

    [Tooltip("�v���C���[�̌��݂̍��W")]
    private Vector3 _playerCurrentPos;
    [Tooltip("�G�̌��݂̍��W")]
    private Vector3 _enemyCurrentPos;

    private GameObject _player;
    private GameObject _enemy;

    private float _sum = 0;

    private bool _isMove = false;

    private void Start()
    {
        if (_start.position.x >= _end.position.x)
        {
            Debug.LogError("���W���s���Ȓl�ł�");
            return;
        }
        _sum = Mathf.Abs(_start.position.x) + Mathf.Abs(_end.position.x);

        if (_playerPrefab != null)
        {
            _player = Instantiate(_playerPrefab, _playerInitPos.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("�v���n�u��Player��ݒ肵�Ă�������");
        }

        if (_enemyPrefab != null)
        {
            _enemy = Instantiate(_enemyPrefab, _enemyInitPos.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("�v���n�u��Enemy��ݒ肵�Ă�������");
        }

        if (_kbDistance <= 0)
        {
            Debug.LogError("�m�b�N�o�b�N�����̒l��ݒ肵�Ă�������");
        }
        if (_kbTime <= 0)
        {
            Debug.Log("�m�b�N�o�b�N���Ԃ�ݒ肵�Ă�������");
        }

        _isMove = true;

        Init();
    }

    /// <summary>
    /// Player��Enemy�̈ʒu���̏�����
    /// </summary>
    public void Init()
    {
        if (_playerInitPos != null)
        {
            _playerCurrentPos = _playerInitPos.position;
        }
        if (_enemyInitPos != null)
        {
            _enemyCurrentPos = _enemyInitPos.position;
        }
    }

    private void Update()
    {
        if (_isMove == false) return;

        PlayerMove(_player.transform);
        EnemyMove(_enemy.transform);

        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);

        _isMove = DistanceCheck(playerLerp, enemyLerp);
    }

    /// <summary>
    /// �^����ꂽ�l����`�⊮�ɕϊ�����
    /// </summary>
    /// <param name="xPos">�ϊ�������W��X���W</param>
    /// <returns></returns>
    private float LerpTranslate(float xPos)
    {
        if (_start.position.x > xPos || _end.position.x < xPos)
        {
            Debug.LogError("Stage����O��Ă��܂�");
            return 0;
        }

        float value = (xPos - _start.position.x) / _sum;
        Debug.Log(value);
        return value;
    }

    /// <summary>
    /// Player�̈ړ��ATransform.Translate���g��
    /// </summary>
    /// <param name="tr"></param>
    private void PlayerMove(Transform tr)
    {
        tr.Translate(Vector3.right * Time.deltaTime * _playerSpeed);
    }

    /// <summary>
    /// Enemy�̈ړ��ATransform.Translate���g��
    /// </summary>
    /// <param name="tr"></param>
    private void EnemyMove(Transform tr)
    {
        tr.Translate(Vector3.left * Time.deltaTime * _enemySpeed);
    }

    /// <summary>
    /// �v���C���[�ƃG�l�~�[�̋�����r
    /// </summary>
    /// <param name="p"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool DistanceCheck(float p, float e)
    {
        if (e - p <= _stopDistance)
        {
            KnockBackEnemy();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void KnockBackEnemy()
    {
        _enemy.transform.DOLocalMove
            (_enemy.transform.position + _enemy.transform.right * _kbDistance, _kbTime)
            .OnComplete(() => _isMove = true
            );

    }
}