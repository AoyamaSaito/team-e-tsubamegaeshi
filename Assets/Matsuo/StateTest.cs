using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    public enum BattleState
    {
        //�Ƃ肠��������񂯂����
        NONE = 0,
        Rock = 1,//�O�[/Right
        Scissors = 2,//�`���L/Light
        Paper = 3//�p�[/Down
    }

    [SerializeField]//�m�F�p�@player�̃A�N�V����
    private BattleState _playerState = BattleState.NONE;

    [SerializeField]//�m�F�p�@enemy�̃A�N�V����
    private BattleState _enemyState = BattleState.NONE;

    public enum BattleEndState//���s
    {
        NONE = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
    }
    [SerializeField]
    private BattleEndState battleEndState = BattleEndState.NONE;

    //[SerializeField]
    //Battele _battele;

    [SerializeField]//�m�F�p
    FlickTest _flickTest;//�t���b�N����

    //[SerializeField]
    //bool _isBattele;
    private void Update()
    {
        Battle();
        //if (_battele.IsBattle && !_isBattele)
        //{
        //    BattleStart();
        //}
        //if(_battele.IsBattle)
        //{
        //    PlayerStateSet();
        //}
    }

    /// <summary>
    /// �퓬�J�n���ɌĂԏ���
    /// </summary>
    public void BattleStart()
    {
        //_isBattele = true;
        Debug.Log("�퓬�J�n");
        EnemyStateSet();
        //PlayerStateSet();
    }

    /// <summary>
    /// �G�l�~�[�̏o��������߂ĕύX���鏈��
    /// </summary>
    void EnemyStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch(rdm)
        {
            case 1:
                _enemyState = BattleState.Rock;
                Debug.Log($"�G:{BattleState.Rock}" );
                break;
            case 2:
                _enemyState = BattleState.Scissors;
                Debug.Log($"�G:{BattleState.Scissors}");
                break;
            case 3:
                _enemyState = BattleState.Paper;
                Debug.Log($"�G:{BattleState.Paper}");
                break;
        }
    }

    /// <summary>
    /// �f�o�b�N�p
    /// </summary>
    void PlayerStateSet()
    {

        switch (_flickTest.NowSwipe)
        {
            case FlickTest.FlickState.LEFT:
                _playerState = BattleState.Rock;
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Rock}");
                break;
            case FlickTest.FlickState.RIGHT:
                _playerState = BattleState.Scissors;
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Scissors}");
                break;
            case FlickTest.FlickState.DOWN:
                _playerState = BattleState.Paper;
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Paper}");
                break;
            case FlickTest.FlickState.NONE:
                _playerState = BattleState.NONE;
                Battle();
                Debug.Log($"�v���C���[:{BattleState.NONE}");
                break;
        }
    }
    /// <summary>
    /// �f�o�b�N�p�X�e�[�g���Z�b�g
    /// </summary>
    void StateReSet()
    {
        _playerState = BattleState.NONE;
        _enemyState = BattleState.NONE;
    }

    /// <summary>
    /// ���s�𔻒肷�鏈��
    /// </summary>
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
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }

                }
                break;
            case BattleState.Scissors:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                }
                break;
            case BattleState.Paper:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                }
                break;
        }

    }

    /// <summary>
    /// �����ɏ��s�̌�̏����������������͌Ăяo��
    /// </summary>
    /// <param name="next"></param>
    public void ChangeBattleEndState(BattleEndState next)
    {
        //_isBattele = false;
        var prev = battleEndState;
        battleEndState = next;
        switch (battleEndState)
        {
            case BattleEndState.NONE:
                {

                }
                break;

            case BattleEndState.Win:
                {
                    Debug.Log($"�퓬����{next}");

                }
                break;

            case BattleEndState.Lose:
                {
                    Debug.Log($"�퓬����{next}");

                }
                break;

            case BattleEndState.Draw:
                {
                    Debug.Log($"�퓬����{next}");

                }
                break;
        }
    }
}
