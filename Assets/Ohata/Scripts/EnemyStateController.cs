using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void OnEnemyChangeMode(StateManager.BattleState janken)
    {
        switch (ResultManager._resultState)
        {
            case ResultState.NONE:
                {
                    switch (janken)
                    {
                        case StateManager.BattleState.NONE:

                            break;
                        case StateManager.BattleState.Rock:
                            _animator.Play("EnemyAttackRed");
                            Debug.Log($"Enemy�̃A�j���[�V����{StateManager.BattleState.Rock}���Đ�");
                            break;
                        case StateManager.BattleState.Scissors:
                            _animator.Play("EnemyAttackBlue");
                            Debug.Log($"Enemy�̃A�j���[�V����{StateManager.BattleState.Scissors}���Đ�");
                            break;
                        case StateManager.BattleState.Paper:
                            _animator.Play("EnemyAttackGreen");
                            Debug.Log($"Enemy�̃A�j���[�V����{StateManager.BattleState.Paper}���Đ�");
                            break;
                        case StateManager.BattleState.Special:
                            _animator.Play("EnemyAttackSpecial");
                            Debug.Log($"Enemy�̃A�j���[�V����{StateManager.BattleState.Special}���Đ�");
                            break;
                    }
                }
                break;

            case ResultState.WIN:
                {
                    _animator.Play("Death");
                }
                break;

            case ResultState.LOSE:
                {
                    _animator.Play("EnemyWin");
                }
                break;
        }
    }

    public void OnEnemyBsttle(StateManager.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateManager.BattleEndState.NONE:
                break;
            case StateManager.BattleEndState.Win:
                Debug.Log($"Enemy�̏��s{StateManager.BattleEndState.Win}���Đ�");
                break;
            case StateManager.BattleEndState.Lose:
                Debug.Log($"Enemy�̏��s{StateManager.BattleEndState.Lose}���Đ�");
                break;
            case StateManager.BattleEndState.Draw:
                Debug.Log($"Enemyr�̏��s{StateManager.BattleEndState.Draw}���Đ�");
                break;
        }
    }
}
