using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Փx��State
/// </summary>
public enum LevelState
{
    EASY = 0, // ����
    NORMAL = 1, // ����
    HARD = 2, // �㋉
    EXPART = 3, // ���㋉
}

/// <summary>
/// ��Փx�ɉ����āA�v���C���[�ƃG�l�~�[
/// </summary>
public class LevelController : MonoBehaviour
{
    private static LevelController instance;
    public static LevelController Instance
    {
        get
        {
            if (instance == null)
            {
                var LevelControllerPrefab = Resources.Load<LevelController>("LevelManager");
                instance = Instantiate(LevelControllerPrefab);
                DontDestroyOnLoad(Instance);
            }

            return instance;
        }
    }

    [Header("-------------------��Փx�̐ݒ�E�X�e�[�^�X��ݒ�------------------")]
    [Header("��Փx"), SerializeField]
    private LevelState _levelState;

    [Header("�v���C���[�p�X�e�[�^�X")]
    [SerializeField]
    private float _playerSpeed = 1;
    [SerializeField]
    private float _playerKnockbackDistance = 1f;
    [SerializeField]
    private float _playerKnockbackTime = 1f;
    [SerializeField]
    private float _playerAttackInterval = 1f;

    [Header("�G�l�~�[�p�X�e�[�^�X")]
    [SerializeField]
    private float _enemySpeed = 1;
    [SerializeField]
    private float _enemyKnockbackDistance = 1f;
    [SerializeField]
    private float _enemyKnockbackTime = 1f;
    [SerializeField]
    private float _enemyStartPos = 0f;

    [Header("----------------------���L�̍��ڂ͕ύX�s��----------------------")]
    // �v���C���[�̃X�e�[�^�X��ۑ� 
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime 4.AttackInterval
    [Tooltip("Easy�p�v���C���[Status")]
    public float[] _easyPlayerStatus = new float[4];
    [Tooltip("Normal�p�v���C���[Status")]
    public float[] _normalPlayerStatus = new float[4];
    [Tooltip("Hard�p�v���C���[Status")]
    public float[] _hardPlayerStatus = new float[4];
    [Tooltip("EXPART�p�v���C���[Status")]
    public float[] _expartPlayerStatus = new float[4];

    // �G�l�~�[�̃X�e�[�^�X��ۑ�
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime 4.StartPosition
    [Tooltip("Easy�p�G�l�~�[Status")]
    public float[] _easyEnemyStatus = new float[3];
    [Tooltip("Normal�p�G�l�~�[Status")]
    public float[] _normalEnemyStatus = new float[3];
    [Tooltip("Hard�p�G�l�~�[Status")]
    public float[] _hardEnemyStatus = new float[3];
    [Tooltip("EXPART�p�G�l�~�[Status")]
    public float[] _expartEnemyStatus = new float[4];

    private LevelState _nowLevel;

    public LevelState LevelState
    {
        get => _levelState;
        set
        {
            _levelState = value;
            ChangeLevelState(_levelState);
        }
    }

    /// <summary>
    /// �C���X�y�N�^�[��ł�����ۂ̕ύX������
    /// </summary>
    private void OnValidate()
    {

        // �v���C���[�X�e�[�^�X
        _playerSpeed = Mathf.Max(1, _playerSpeed);
        _playerKnockbackDistance = Mathf.Max(1, _playerKnockbackDistance);
        _playerKnockbackTime = Mathf.Max(1, _playerKnockbackTime);
        _playerAttackInterval = Mathf.Max(1, _playerAttackInterval);

        // �G�l�~�[�X�e�[�^�X
        _enemySpeed = Mathf.Max(1, _enemySpeed);
        _enemyKnockbackDistance = Mathf.Max(1, _enemyKnockbackDistance);
        _enemyKnockbackTime = Mathf.Max(1, _enemyKnockbackTime);
        _enemyStartPos = Mathf.Max(0,_enemyStartPos);

        StatusPutIn();
    }

    private void StatusPutIn()
    {
        switch (_levelState)
        {
            case LevelState.EASY:
                {
                    if (_nowLevel != LevelState.EASY)
                    {
                        _playerSpeed = _easyPlayerStatus[0];
                        _playerKnockbackDistance = _easyPlayerStatus[1];
                        _playerKnockbackTime = _easyPlayerStatus[2];
                        _playerAttackInterval = _easyPlayerStatus[3];

                        _enemySpeed = _easyEnemyStatus[0];
                        _enemyKnockbackDistance = _easyEnemyStatus[1];
                        _enemyKnockbackTime = _easyEnemyStatus[2];
                        _enemyStartPos = _easyEnemyStatus[3];
                    }

                    _easyPlayerStatus[0] = _playerSpeed;
                    _easyPlayerStatus[1] = _playerKnockbackDistance;
                    _easyPlayerStatus[2] = _playerKnockbackTime;
                    _easyPlayerStatus[3] = _playerAttackInterval;

                    _easyEnemyStatus[0] = _enemySpeed;
                    _easyEnemyStatus[1] = _enemyKnockbackDistance;
                    _easyEnemyStatus[2] = _enemyKnockbackTime;
                    _easyEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.NORMAL:
                {
                    if (_nowLevel != LevelState.NORMAL)
                    {
                        _playerSpeed = _normalPlayerStatus[0];
                        _playerKnockbackDistance = _normalPlayerStatus[1];
                        _playerKnockbackTime = _normalPlayerStatus[2];
                        _playerAttackInterval = _normalPlayerStatus[3];

                        _enemySpeed = _normalEnemyStatus[0];
                        _enemyKnockbackDistance = _normalEnemyStatus[1];
                        _enemyKnockbackTime = _normalEnemyStatus[2];
                        _enemyStartPos = _normalEnemyStatus[3];
                    }

                    _normalPlayerStatus[0] = _playerSpeed;
                    _normalPlayerStatus[1] = _playerKnockbackDistance;
                    _normalPlayerStatus[2] = _playerKnockbackDistance;
                    _normalPlayerStatus[3] = _playerAttackInterval;

                    _normalEnemyStatus[0] = _enemySpeed;
                    _normalEnemyStatus[1] = _enemyKnockbackDistance;
                    _normalEnemyStatus[2] = _enemyKnockbackTime;
                    _normalEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.HARD:
                {
                    if (_nowLevel != LevelState.HARD)
                    {
                        _playerSpeed = _hardPlayerStatus[0];
                        _playerKnockbackDistance = _hardPlayerStatus[1];
                        _playerKnockbackTime = _hardPlayerStatus[2];
                        _playerAttackInterval = _hardPlayerStatus[3];

                        _enemySpeed = _hardEnemyStatus[0];
                        _enemyKnockbackDistance = _hardEnemyStatus[1];
                        _enemyKnockbackTime = _hardEnemyStatus[2];
                        _enemyStartPos = _hardEnemyStatus[3];
                    }

                    _hardPlayerStatus[0] = _playerSpeed;
                    _hardPlayerStatus[1] = _playerKnockbackDistance;
                    _hardPlayerStatus[2] = _enemyKnockbackTime;
                    _hardPlayerStatus[3] = _playerAttackInterval;

                    _hardEnemyStatus[0] = _enemySpeed;
                    _hardEnemyStatus[1] = _enemyKnockbackDistance;
                    _hardEnemyStatus[2] = _enemyKnockbackTime;
                    _hardEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.EXPART:
                {
                    if(_nowLevel != LevelState.EXPART)
                    {
                        _playerSpeed = _expartPlayerStatus[0];
                        _playerKnockbackDistance = _expartPlayerStatus[1];
                        _playerKnockbackTime = _expartPlayerStatus[2];
                        _playerAttackInterval = _expartPlayerStatus[3];

                        _enemySpeed = _expartEnemyStatus[0];
                        _enemyKnockbackDistance = _expartEnemyStatus[1];
                        _enemyKnockbackTime = _expartEnemyStatus[2];
                        _enemyStartPos = _expartEnemyStatus[3];
                    }

                    _expartPlayerStatus[0] = _playerSpeed;
                    _expartPlayerStatus[1] = _playerKnockbackDistance;
                    _expartPlayerStatus[2] = _enemyKnockbackTime;
                    _expartPlayerStatus[3] = _playerAttackInterval;

                    _expartEnemyStatus[0] = _enemySpeed;
                    _expartEnemyStatus[1] = _enemyKnockbackDistance;
                    _expartEnemyStatus[2] = _enemyKnockbackTime;
                    _expartEnemyStatus[3] = _enemyStartPos;
                }
                break;
        }

        _nowLevel = LevelState;
    }

    private void ChangeLevelState(LevelState _level)
    {
        Debug.Log($"��Փx��{_level}�ɕύX���ꂽ");
    }
}
