using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    //�X�e�[�W�J�ڗp�X�N���v�g

    public void OnClickStartButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        SceneManager.LoadScene("StageScene");
    }



}
