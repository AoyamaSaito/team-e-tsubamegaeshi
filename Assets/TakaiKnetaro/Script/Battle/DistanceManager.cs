using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

/// <summary>
/// �V�[������Player��Enemy�̈ʒu���Ǘ�����
/// </summary>
public class DistanceManager : MonoBehaviour
{
    [Header("�v���C���[")]
    [SerializeField, Tooltip("�v���C���[�̃v���n�u")]
    private GameObject _playerPrefab;
    [SerializeField, Tooltip("�v���C���[�̏������W")]
    private Transform _playerInitPos;

    [Header("�G")]
    [SerializeField, Tooltip("�G�̃v���n�u")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("�G�̏������W")]
    private Transform _enemyInitPos;

    [Header("�X�e�[�W�ݒ�")]
    [SerializeField, Tooltip("�X�e�[�W�̍ō�")]
    private Transform _start;
    [SerializeField, Tooltip("�X�e�[�W�̍ŉE")]
    private Transform _end;
    [SerializeField, Tooltip("�Î~������`����")]
    private float _stopDistance = 0.05f;
    [SerializeField, Tooltip("�K�E!���Ԃ�!!���鋗��")]
    private float _tsubamegaeshiPos = 25f;

    [Header("�}�l�[�W���[")]
    [SerializeField, Tooltip("StateTest")]
    private StateManager _stateManager;
    [SerializeField]
    private TargetCamera _targetCamera;

    [Tooltip("�v���C���[�̌��݂̍��W")]
    private Vector3 _playerCurrentPos;
    [Tooltip("�G�̌��݂̍��W")]
    private Vector3 _enemyCurrentPos;
    [SerializeField]
    private float _attackInterval = 1f;

    private GameObject _player;
    private CharacterScript _charaPlayer;
    private GameObject _enemy;
    private CharacterScript _charaEnemy;

    private float _sum = 0;

    public bool _isBattleCheck = false;

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
            _targetCamera._objects[0] = _player.transform;
            _stateManager._playerStateController = _player.GetComponent<PlayerStateController>();
            _charaPlayer = _player.GetComponent<CharacterScript>();
        }
        else
        {
            Debug.LogError("�v���n�u��Player��ݒ肵�Ă�������");
        }

        if (_enemyPrefab != null)
        {
            _enemy = Instantiate(_enemyPrefab, _enemyInitPos.position, Quaternion.identity);
            _targetCamera._objects[1] = _enemy.transform;
            _stateManager._enemyStateController = _enemy.GetComponent<EnemyStateController>();
            _charaEnemy = _enemy.GetComponent<CharacterScript>();
        }
        else
        {
            Debug.LogError("�v���n�u��Enemy��ݒ肵�Ă�������");
        }

        _isBattleCheck = true;

        Init();

        _targetCamera.OnTarget();
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
        if (_isBattleCheck == false) return;

        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);

        _isBattleCheck = DistanceCheck(playerLerp, enemyLerp);

        if(!_isBattleCheck)
        {
            _stateManager.AttackTimer();
        }
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
        //Debug.Log(value);
        return value;
    }

    public void SetUp(StateManager.BattleEndState battle)
    {
        if (battle == StateManager.BattleEndState.Win)
        {
            _charaEnemy.KnockBack();
            _charaPlayer.MoveStart();
        }
        else if (battle == StateManager.BattleEndState.Lose)
        {
            Debug.Log("����");
            //Destroy(_player);
        }
        else if (battle == StateManager.BattleEndState.Draw)
        {
            _charaPlayer.KnockBack();
            _charaEnemy.MoveStart();
        }
        StartCoroutine(ResetInterval());
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
            _charaPlayer._isMove = true;
            _charaEnemy._isMove = true;
            _stateManager.EnemyStateSet();
            return false;
        }
        else if(e >= _tsubamegaeshiPos) // �K�E!���Ԃ�!!
        {
            _charaEnemy._isMove = true;
            Debug.Log("�K�E!���Ԃ�!!");
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator ResetInterval()
    {
        yield return new WaitForSeconds(_stateManager._interval);
        //_charaPlayer._isMove = false;
        //_charaEnemy._isMove = false;
        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);
        _isBattleCheck = DistanceCheck(playerLerp, enemyLerp);
    }
}