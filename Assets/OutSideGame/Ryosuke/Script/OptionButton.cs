using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    //�I�v�V�����V�[���J�ڗp�X�N���v�g

    public void OnClickOptionButton()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
