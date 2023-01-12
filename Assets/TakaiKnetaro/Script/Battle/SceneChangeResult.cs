using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeResult : MonoBehaviour
{
    [SerializeField,Tooltip("�ړ��܂łɊ|���鎞��")]
    private float _timer;

    public void GoResult()
    {
        StartCoroutine(GoResultTimer());
    }

    IEnumerator  GoResultTimer()
    {
        yield return new WaitForSeconds(_timer);
        SceneManager.LoadScene("Result");
    }
}
