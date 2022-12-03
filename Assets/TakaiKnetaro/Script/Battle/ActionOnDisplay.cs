using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionOnDisplay : MonoBehaviour
{
    [SerializeField]
    private Renderer _actionImage; // �U�����̉摜

    private float _displayTime = 1f; // �摜�̕\������

    private void Start()
    {
        //_actionImage = GameObject.Find("ActionDisplay").GetComponent<Renderer>();
        //_actionImage.gameObject.SetActive(false);
    }

    public void OnDisplay(Color color, float time)
    {
        if(_actionImage == null) 
        {
            _actionImage = GameObject.Find("ActionDisplay").GetComponent<Renderer>();
            _actionImage.gameObject.SetActive(false);
        }

        _displayTime = time;

        _actionImage.material.color = color;
        _actionImage.gameObject.SetActive(true);
        StartCoroutine(nameof(DisplayTime));
    }

    IEnumerator DisplayTime()
    {
        yield return new WaitForSeconds(_displayTime);
        _actionImage?.gameObject.SetActive(false);
    }
}
