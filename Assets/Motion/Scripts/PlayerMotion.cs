using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotion : MonoBehaviour
{
    //�֐��Ńv���C���[�̃A�j���[�V�������Ăяo����
    [SerializeField] Animator _animator;
    public void motion()
    {
        _animator.SetTrigger("New Trigger");
    }
}
