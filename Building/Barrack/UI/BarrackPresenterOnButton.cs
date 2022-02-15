using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BarrackPresenterOnButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _progressImage;
    [SerializeField] private Button _button;
    [SerializeField] private Text _price;

    public void Present(ProductionElement element, UnityAction onClick)
    {
        _image.sprite = element.Icon;
        _progressImage.fillAmount = 0;
        if(gameObject.GetComponentInParent<PossibleProduction>())
        {
            _price.gameObject.SetActive(true);
            _price.text = element.Price.Value.ToString();
        }
        _button.onClick.AddListener(onClick);
    }

    public void SetProgress(float normalizedProgress)
    {
        _progressImage.fillAmount = normalizedProgress;
    }
}
