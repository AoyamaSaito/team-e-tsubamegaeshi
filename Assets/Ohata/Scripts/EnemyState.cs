using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    void Start()
    {
        _animator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnemyChangeMode(StateTest.BattleState janken)
    {
        switch (janken)
        {
            case StateTest.BattleState.NONE:

                break;
            case StateTest.BattleState.Rock:
                _animator.Play("EnemyAttackRed");
                Debug.Log($"Enemy�̃A�j���[�V����{StateTest.BattleState.Rock}���Đ�");
                break;
            case StateTest.BattleState.Scissors:
                _animator.Play("EnemyAttackBlue");
                Debug.Log($"Enemy�̃A�j���[�V����{StateTest.BattleState.Scissors}���Đ�");
                break;
            case StateTest.BattleState.Paper:
                _animator.Play("EnemyAttackGreen");
                Debug.Log($"Enemy�̃A�j���[�V����{StateTest.BattleState.Paper}���Đ�");
                break;
        }

    }

    public void OnEnemyBsttle(StateTest.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateTest.BattleEndState.NONE:
                break;
            case StateTest.BattleEndState.Win:
                Debug.Log($"Enemy�̏��s{StateTest.BattleEndState.Win}���Đ�");
                break;
            case StateTest.BattleEndState.Lose:
                Debug.Log($"Enemy�̏��s{StateTest.BattleEndState.Lose}���Đ�");
                break;
            case StateTest.BattleEndState.Draw:
                Debug.Log($"Enemyr�̏��s{StateTest.BattleEndState.Draw}���Đ�");
                break;
        }
    }
}
