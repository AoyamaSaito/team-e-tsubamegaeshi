using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

//TODO
//PlayerとEnemy両方の管理を行うとコード量が多くなるかも
//必要であれば分割する

/// <summary>
/// シーン内のPlayerとEnemyの位置を管理する
/// </summary>
public class DistanceManager : MonoBehaviour
{
    [Header("プレイヤー")]
    [SerializeField, Tooltip("プレイヤーのプレハブ")]
    private GameObject _playerPrefab;
    [SerializeField, Tooltip("プレイヤーの初期座標")]
    private Transform _playerInitPos;

    [Header("敵")]
    [SerializeField, Tooltip("敵のプレハブ")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("敵の初期座標")]
    private Transform _enemyInitPos;

    [Header("ステージ設定")]
    [SerializeField, Tooltip("ステージの最左")]
    private Transform _start;
    [SerializeField, Tooltip("ステージの最右")]
    private Transform _end;
    [SerializeField, Tooltip("静止する線形距離")]
    private float _stopDistance = 0.05f;

    [Header("マネージャー")]
    [SerializeField, Tooltip("StateTest")]
    private StateManager _stateTest;

    [Tooltip("プレイヤーの現在の座標")]
    private Vector3 _playerCurrentPos;
    [Tooltip("敵の現在の座標")]
    private Vector3 _enemyCurrentPos;

    private GameObject _player;
    private CharacterScript _charaPlayer;
    private GameObject _enemy;
    private CharacterScript _charaEnemy;

    private float _sum = 0;

    public bool _isCheck = false;

    private void Start()
    {
        if (_start.position.x >= _end.position.x)
        {
            Debug.LogError("座標が不正な値です");
            return;
        }
        _sum = Mathf.Abs(_start.position.x) + Mathf.Abs(_end.position.x);

        if (_playerPrefab != null)
        {
            _player = Instantiate(_playerPrefab, _playerInitPos.position, Quaternion.identity);
            _stateTest._playerStateController = _player.GetComponent<PlayerStateController>();
            _charaPlayer = _player.GetComponent<CharacterScript>();
        }
        else
        {
            Debug.LogError("プレハブにPlayerを設定してください");
        }

        if (_enemyPrefab != null)
        {
            _enemy = Instantiate(_enemyPrefab, _enemyInitPos.position, Quaternion.identity);
            _stateTest._enemyStateController = _enemy.GetComponent<EnemyStateController>();
            _charaEnemy = _enemy.GetComponent<CharacterScript>();
        }
        else
        {
            Debug.LogError("プレハブにEnemyを設定してください");
        }

        _isCheck = true;

        Init();
    }

    /// <summary>
    /// PlayerとEnemyの位置情報の初期化
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
        if (_isCheck == false) return;

        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);

        _isCheck = DistanceCheck(playerLerp, enemyLerp);
    }

    /// <summary>
    /// 与えられた値を線形補完に変換する
    /// </summary>
    /// <param name="xPos">変換する座標のX座標</param>
    /// <returns></returns>
    private float LerpTranslate(float xPos)
    {
        if (_start.position.x > xPos || _end.position.x < xPos)
        {
            Debug.LogError("Stageから外れています");
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
        }
        else if (battle == StateManager.BattleEndState.Lose)
        {
            _charaPlayer.KnockBack();
        }
        else if (battle == StateManager.BattleEndState.Draw)
        {
            _charaPlayer.KnockBack();
            _charaEnemy.KnockBack();
        }
        StartCoroutine(nameof(ResetInterval));
    }

    /// <summary>
    /// プレイヤーとエネミーの距離比較
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
            _stateTest.EnemyStateSet();
            return false;
        }
        else
        {
            _charaPlayer._isMove = false;
            _charaEnemy._isMove = false;
            return true;
        }
    }

    IEnumerator ResetInterval()
    {
        yield return new WaitForSeconds(_stateTest._interval);
        _charaPlayer._isMove = false;
        _charaEnemy._isMove = false;
        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);
        _isCheck = DistanceCheck(playerLerp, enemyLerp);
    }
}