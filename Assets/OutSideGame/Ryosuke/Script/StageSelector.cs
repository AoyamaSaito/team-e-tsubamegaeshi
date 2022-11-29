using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{
    [Header("���C����ʂ̑J�ڊǗ�")]
    [Header("�t�F�C�h�C���A�A�E�g�̃X�s�[�h���ς������")]

    [SerializeField] private float _fadeTime = 2.0f;
    [SerializeField] Fade fade;

    public void OnClickEasyButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime, () => SceneManager.LoadScene("TakaiScene"));
    }

    public void OnClickNomalButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime, () => SceneManager.LoadScene("NomalScene"));
    }

    public void OnClickHardButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime, () => SceneManager.LoadScene("HardScene"));
    }

    public void OnClickExtraButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime, () => SceneManager.LoadScene("ExtraScene"));
    }
}
