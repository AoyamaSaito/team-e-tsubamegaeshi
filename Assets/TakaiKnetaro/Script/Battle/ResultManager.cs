using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResultState
{
    WIN = 0,
    LOSE = 1,
}

public class ResultManager : MonoBehaviour
{
    static public ResultState _resultState;

    void Start()
    {
        switch (_resultState)
        {
            case ResultState.WIN: //勝った時の処理
                {

                }
                break;

            case ResultState.LOSE: //負けた時の処理
                {

                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
