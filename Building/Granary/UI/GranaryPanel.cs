using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GranaryPanel : MonoBehaviour
{ 
    public static GranaryPanel Instance { get; private set; }

    [SerializeField] private Text _name;
    [SerializeField] private Image _icon;
    public UnityAction<int> OnValueChanged;
    public GameObject Body => _body;
    [SerializeField] private GameObject _body;
    [SerializeField] private Text _mood;
    [SerializeField] private Text _food;

    [SerializeField] private Button _minus;
    [SerializeField] private Button _plus;
    private Feed _feed;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void Start()
    {
        _plus.onClick.AddListener(Plus);
        _minus.onClick.AddListener(Minus);

        Body.SetActive(false);
    }

    private void Plus()
    {
        if (_feed.CurrentValue < Feed.MAX)
        {
            OnValueChanged?.Invoke(+1);
        }
    }

    private void Minus()
    {
        if (_feed.CurrentValue > 1)
        {
            OnValueChanged?.Invoke(-1);
        }
    }

    public void InitFeed(Feed feed)
    {
        _feed = feed;
    }

    public void DisplayPanel(BuildingProfile profile)
    {
        Body.SetActive(true);
        _name.text = profile.Name;
        _icon.sprite = profile.Icon;
        _feed.Recount();
    }

    public void DisplayIncome(float food, float mood)
    {
        _food.text = food.ToString();
        _mood.text = mood.ToString();
    }
}
