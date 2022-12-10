using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                instance = FindObjectOfType<LevelController>();
            }

            return instance;
        }
    }

    /// <summary>
    /// ��Փx��State
    /// </summary>
    public enum LevelState
    {
        EASY = 0,
        NORMAL = 1,
        HARD = 2,
    }

    [Header("��Փx")]
    public LevelState _levelState;

    [Header("�v���C���[�p�X�e�[�^�X")]
    [SerializeField]
    private float _playerSpeed = 1;
    [SerializeField]
    private float _playerKnockbackDistance = 1f;
    [SerializeField]
    private float _playerKnockbackTime = 1f;

    [Header("�G�l�~�[�p�X�e�[�^�X")]
    [SerializeField]
    private float _enemySpeed = 1;
    [SerializeField]
    private float _enemyKnockbackDistance = 1f;
    [SerializeField]
    private float _enemyKnockbackTime = 1f;

    /// <summary>
    /// �C���X�y�N�^�[��ł�����ۂ̕ύX������
    /// </summary>
    private void OnValidate()
    {
        // �v���C���[�X�e�[�^�X
        _playerSpeed = Mathf.Max(1, _playerSpeed);
        _playerKnockbackDistance = Mathf.Max(1, _playerKnockbackDistance);
        _playerKnockbackTime = Mathf.Max(1, _playerKnockbackTime);

        // �G�l�~�[�X�e�[�^�X
        _enemySpeed = Mathf.Max(1, _enemySpeed);
        _enemyKnockbackDistance = Mathf.Max(1, _enemyKnockbackDistance);
        _enemyKnockbackTime = Mathf.Max(1, _enemyKnockbackTime);

        switch (_levelState)
        {
            case LevelState.EASY:
                {
                    
                }
                break;

            case LevelState.NORMAL:
                {
                    
                }
                break;

            case LevelState.HARD:
                {
                   
                }
                break;
        }

    }
}
