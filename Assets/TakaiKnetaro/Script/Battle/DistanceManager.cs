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
    [SerializeField, Tooltip("敵を停止する位置")]
    private float _enemyStopPos = 0.95f;

    [Header("マネージャー")]
    [SerializeField, Tooltip("StateTest")]
    private StateManager _stateManager;
    [SerializeField]
    private TargetCamera _targetCamera;
    [SerializeField]
    private SceneChangeResult _sceneChangeResult;

    [Tooltip("プレイヤーの現在の座標")]
    private Vector3 _playerCurrentPos;
    [Tooltip("敵の現在の座標")]
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
            Debug.LogError("座標が不正な値です");
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
            Debug.LogError("プレハブにPlayerを設定してください");
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
            Debug.LogError("プレハブにEnemyを設定してください");
        }

        _enemyStopPos = (_end.position.x - _start.position.x) * _enemyStopPos + _start.position.x;

        _isBattleCheck = true;

        Init();

        _targetCamera.OnTarget();
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
        if (_isBattleCheck == false) return;

        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);

        
        _isBattleCheck = DistanceCheck(playerLerp, enemyLerp);
        
        if(_isBattleCheck)
        {
            _isBattleCheck = SpecialCheck(_enemy.transform.position.x);
        }
 
        if (!_isBattleCheck)
        {
            _stateManager.AttackTimer();
        }
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
            _charaPlayer.MoveStart();
        }
        else if (battle == StateManager.BattleEndState.Lose)
        {
            Debug.Log("負け");
            ResultManager._resultState = ResultState.LOSE;
            _sceneChangeResult.MoveScene();
            //Destroy(_player);
        }
        else if (battle == StateManager.BattleEndState.Draw)
        {
            _charaPlayer.KnockBack();
            _charaEnemy.MoveStart();
        }
        else if (battle == StateManager.BattleEndState.Special)
        {
            Debug.Log("勝利");
            ResultManager._resultState = ResultState.WIN;
            _sceneChangeResult.MoveScene();
        }
        StartCoroutine(ResetInterval());
    }

    /// <summary>
    /// エネミーのX軸が一定距離を超えたら機能する関数
    /// </summary>
    /// <param name="posx"></param>
    /// <returns></returns>
    private bool SpecialCheck(float posx)
    {
        if (posx >= _enemyStopPos)
        {
            _stateManager.EnemyStateSpecial();
            _charaPlayer._isMove = true;
            _charaEnemy._isMove = true;
            _isBattleCheck = false;
            return false;
        }
        else
        {
            return true;
        }
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
            _isBattleCheck = false;
            _stateManager.EnemyStateSet();
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
        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);
        _isBattleCheck = DistanceCheck(playerLerp, enemyLerp);
    }
}