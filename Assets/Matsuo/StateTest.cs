using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    public enum BattleState
    {
        //�Ƃ肠��������񂯂����
        NONE = 0,
        Rock = 1,//�O�[Right
        Scissors = 2,//�`���LLight
        Paper = 3//�p�[Down
    }

    [SerializeField]
    private BattleState _playerState = BattleState.NONE;

    [SerializeField]
    private BattleState _enemyState = BattleState.NONE;


    private void Update()
    {
        Battle();
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnemyStateSet();
            PlayerStateSet();
        }
    }

    void EnemyStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch(rdm)
        {
            case 1:
                _enemyState = BattleState.Rock;
                break;
            case 2:
                _enemyState = BattleState.Scissors;
                break;
            case 3:
                _enemyState = BattleState.Paper;
                break;
        }
    }

    void PlayerStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch (rdm)
        {
            case 1:
                _playerState = BattleState.Rock;
                break;
            case 2:
                _playerState = BattleState.Scissors;
                break;
            case 3:
                _playerState = BattleState.Paper;
                break;
        }
    }

    void StateReSet()
    {
        _playerState = BattleState.NONE;
        _enemyState = BattleState.NONE;

    }
    void Battle()
    {
        switch (_playerState)
        {
            case BattleState.NONE:
                {
                }
                break;
            case BattleState.Rock:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("������");
                        StateReSet();
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("����");
                        StateReSet();
                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("����");
                        StateReSet();
                    }
                }
                break;
            case BattleState.Scissors:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("����");
                        StateReSet();
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("������");
                        StateReSet();

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("����");
                        StateReSet();
                    }
                }
                break;
            case BattleState.Paper:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("����");
                        StateReSet();
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("����");
                        StateReSet();

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("������");
                        StateReSet();
                    }
                }
                break;
        }

    }
}
