using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotion : MonoBehaviour
{
    //�֐��Ńv���C���[�̃A�j���[�V�������Ăяo����
    [SerializeField] Animator _playerAnimator;
    public void motion()
    {
        _playerAnimator.SetTrigger("New Trigger");
    }
}
