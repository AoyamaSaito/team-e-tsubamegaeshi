using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateTest;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void OnPlayerChangeMode(StateTest.BattleState janken)
    {
        switch (janken)
        {
            case StateTest.BattleState.NONE:

                break;
            case StateTest.BattleState.Rock:
                _animator.Play("PlayerAttackRed");
                Debug.Log($"Player�̃A�j���[�V����{StateTest.BattleState.Rock}���Đ�");
                break;
            case StateTest.BattleState.Scissors:
                _animator.Play("PlayerAttackBlue");
                Debug.Log($"Player�̃A�j���[�V����{StateTest.BattleState.Scissors}���Đ�");
                break;
            case StateTest.BattleState.Paper:
                _animator.Play("PlayerAttackGreen");
                Debug.Log($"Player�̃A�j���[�V����{StateTest.BattleState.Paper}���Đ�");
                break;
        }

    }

    public void OnPlayerBsttle(StateTest.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateTest.BattleEndState.NONE:
                break;
            case StateTest.BattleEndState.Win:
                Debug.Log($"Player�̏��s{StateTest.BattleEndState.Win}���Đ�");
                break;
            case StateTest.BattleEndState.Lose:
                Debug.Log($"Player�̏��s{StateTest.BattleEndState.Lose}���Đ�");
                break;
            case StateTest.BattleEndState.Draw:
                Debug.Log($"Player�̏��s{StateTest.BattleEndState.Draw}���Đ�");
                break;
        }
    }
}
