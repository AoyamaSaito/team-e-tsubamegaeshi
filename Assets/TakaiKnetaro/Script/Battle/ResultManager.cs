using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResultState
{
    WIN = 0,
    LOSE = 1,
}

public class ResultManager : MonoBehaviour
{
    static public ResultState _resultState;

    [SerializeField]
    private Text _text;

    void Start()
    {
        switch (_resultState)
        {
            case ResultState.WIN: //���������̏���
                {
                    ResultWin();
                }
                break;

            case ResultState.LOSE: //���������̏���
                {
                    ResultLose();
                }
                break;
        }

    }

    private void ResultWin()
    {
        _text.text = "����";
    }

    private void ResultLose()
    {
        _text.text = "����";
    }

}
