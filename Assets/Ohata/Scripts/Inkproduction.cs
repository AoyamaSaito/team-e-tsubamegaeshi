using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Inkproduction : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _Sumi;
    [SerializeField]
    private GameObject _gazou;


    [SerializeField]
    private float _intkTime = 0.5f;
   
    void Start()
    {
        _gazou.SetActive(false);
        StartCoroutine(InkCoroutine());
       
    }




    public IEnumerator InkCoroutine()
    {
        Debug.Log("�n���ۂ��ۂ��\��");
        for (int i = 0; i < _Sumi.Length; i++)
        {
            _Sumi[i].SetActive(true);
            yield return new WaitForSeconds(_intkTime);
        }
        Debug.Log("�n�̉摜�S���\��");
        yield return new WaitForSeconds(1.0f);
        _gazou.SetActive(true);
        
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("ResultScene");
        yield return null;
        _gazou.SetActive(false);

        for (int i = 0; i < _Sumi.Length; i++)
        {
            _Sumi[i].SetActive(false);
            yield return new WaitForSeconds(_intkTime);
        }
        
    }
}
