using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [Header("�����Ńt�F�[�h�̃X�s�[�g��ς�����")]
    [Header("�J�ڎ��Ԃ����߂��惈")]
    [SerializeField] private float _fadeOutSpeed = 2.0f;
    [SerializeField] Fadeout fadeOut;

    public void Start()
    {
        fadeOut.FadeOut(_fadeOutSpeed);
    }
}
