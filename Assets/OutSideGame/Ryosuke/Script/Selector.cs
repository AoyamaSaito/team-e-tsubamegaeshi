using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    [Header("���C����ʂ̑J�ڊǗ�")]
    [Header("�t�F�[�h�C���̑J�ڎ��Ԃ����߂����")]

    [SerializeField] private float _fadeTime = 2.0f;
    [SerializeField] Fade fade;

    public void OnClickStartButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime , () => SceneManager.LoadScene("StageScene"));
    }

    public void OnClickOptionButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime , () => SceneManager.LoadScene("OptionScene"));
    }
}
