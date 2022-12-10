using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// ��Փx��State
    /// </summary>
    public enum LevelState
    {
        EASY = 0,
        NORMAL = 1,
        HARD = 2,
    }

    public LevelState _levelState => LevelState.EASY;

    [Header("Easy�p�X�e�[�^�X")]
    [Header("�v���C���[")]
    [SerializeField]
    private float _easyPlayerSpeed = 1;
    [SerializeField]
    private float _easyPlayerKnockbackDistance = 1f;
    [SerializeField]
    private float _easyPlayerKnockbackTime = 1f;
    [Header("�G�l�~�[")]
    [SerializeField]
    private float _easyEnemySpeed = 1;
    [SerializeField]
    private float _easyEnemyKnockbackDistance = 1f;
    [SerializeField]
    private float _easyEnemyKnockbackTime = 1f;

    [Header("Normal�p�X�e�[�^�X")]

    [Header("Hard�p�X�e�[�^�X")]
    int _enemyKnockbackLevel = 0;
}
