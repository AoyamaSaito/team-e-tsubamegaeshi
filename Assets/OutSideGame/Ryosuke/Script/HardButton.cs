using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour
{
    //��Փx�u�n�[�h�v�ɑJ�ڂ��邽�߂̃{�^��

    public void OnClickHardButton()
    {
        AudioManager.Instance.PlaySE("SE_RepelEnemy_DEMO_Ver.2_20221101");
        SceneManager.LoadScene("HardScene");
    }
}
