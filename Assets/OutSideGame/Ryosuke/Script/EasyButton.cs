using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyButton : MonoBehaviour
{
    //��Փx�u�C�[�W�[�v�ɑJ�ڂ��邽�߂̃{�^��

    public void OnClickEasyButton()
    {
        AudioManager.Instance.PlaySE("SE_RepelEnemy_DEMO_Ver.2_20221101");
        SceneManager.LoadScene("EasyScene");
    }
}
