using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    [SerializeField]
    private Text _fpsText;
    [SerializeField]
    private Text _fpsAverageText;
    private int _fps;
    private int[] _fpsArray;
    private int index;

    private void Start()
    {
        _fpsArray = new int[200];
    }

    private void Update()
    {
        _fps = (int)(1.0f / Time.deltaTime);

        _fpsText.text = _fps.ToString();

        _fpsArray[index] = _fps;
        float average = _fpsArray.Sum() / _fpsArray.Length;
        _fpsAverageText.text = average.ToString();
        index++;
        index = index > 199 ? 0 : index;

        //Debug.Log(_fps);
    }
}
