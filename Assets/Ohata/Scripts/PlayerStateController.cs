using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManager;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void OnPlayerChangeMode(StateManager.BattleState janken)
    {
        switch (janken)
        {
            case StateManager.BattleState.NONE:

                break;
            case StateManager.BattleState.Rock:
                _animator.Play("PlayerAttackRed");
                Debug.Log($"Player�̃A�j���[�V����{StateManager.BattleState.Rock}���Đ�");
                break;
            case StateManager.BattleState.Scissors:
                _animator.Play("PlayerAttackBlue");
                Debug.Log($"Player�̃A�j���[�V����{StateManager.BattleState.Scissors}���Đ�");
                break;
            case StateManager.BattleState.Paper:
                _animator.Play("PlayerAttackGreen");
                Debug.Log($"Player�̃A�j���[�V����{StateManager.BattleState.Paper}���Đ�");
                break;
        }

    }

    public void OnPlayerBsttle(StateManager.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateManager.BattleEndState.NONE:
                break;
            case StateManager.BattleEndState.Win:
                Debug.Log($"Player�̏��s{StateManager.BattleEndState.Win}���Đ�");
                break;
            case StateManager.BattleEndState.Lose:
                Debug.Log($"Player�̏��s{StateManager.BattleEndState.Lose}���Đ�");
                break;
            case StateManager.BattleEndState.Draw:
                Debug.Log($"Player�̏��s{StateManager.BattleEndState.Draw}���Đ�");
                break;
        }
    }
}
