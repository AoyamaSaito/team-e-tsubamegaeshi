using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NomalButton : MonoBehaviour
{
    //��Փx�u�m�[�}���v�ɑJ�ڂ��邽�߂̃{�^��

    public void OnClickNomalButton()
    {
        AudioManager.Instance.PlaySE("SE_RepelEnemy_DEMO_Ver.2_20221101");
        SceneManager.LoadScene("NomalScene");
    }
    
}
