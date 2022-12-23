using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneSelector : MonoBehaviour
{
    [Serializable]
    class ChangeSetting
    {
        public string Scene;
        public Button Button;
    }

    [Header("��ʂ̑J�ڊǗ�")]
    [Header("�t�F�[�h�C���̑J�ڎ��Ԃ����߂����")]
    [SerializeField] private float _fadeTime = 2.0f;
    
    [SerializeField,Header("SE�̖��O���R�s�y���ē���Ă�������")] string se;
    [SerializeField,Header("BGM�̋Ȗ����R�s�y���ē���Ă�������")] string bgm;

    
    [SerializeField,Header("������FadeCanvas�̃v���n�u�����Ă�������")] Fade fade;
    [SerializeField] List<ChangeSetting> Setting;

    private void Awake()
    {
        AudioManager.Instance.PlayBgm(bgm);
        Setting.ForEach(s =>
        {
            s.Button.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySE(se);
                fade.FadeIn(_fadeTime, () => SceneManager.LoadScene(s.Scene));
            });
        });
    }
}
