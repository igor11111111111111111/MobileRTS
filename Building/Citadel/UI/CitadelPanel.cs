
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
  
public class CitadelPanel : BuildingPanel
{
    public static CitadelPanel Instance { get; private set; }

    public UnityAction<int> OnValueChanged;

    [SerializeField] private Text _mood;
    [SerializeField] private Text _gold;
    [SerializeField] private Button _minus;
    [SerializeField] private Button _plus;

    private Tax _tax;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    } 

    protected override void Start()
    {
        base.Start();

        _plus.onClick.AddListener(Plus);
        _minus.onClick.AddListener(Minus);
    }

    private void Plus()
    {
        if (_tax.CurrentValue < Tax.MAX)
        {
            OnValueChanged?.Invoke(+1);
        }
    }

    private void Minus()
    {
        if (_tax.CurrentValue > 1)
        {
            OnValueChanged?.Invoke(-1);
        }
    }

    public void InitTax(Tax tax)
    {
        _tax = tax;
    }

    public void DisplayPanel(BuildingProfile profile)
    {
        DisplayDefaultInfo(profile);
        _tax.Recount();
    }

    public void DisplayIncome(float gold, float mood)
    {
        _gold.text = gold.ToString();
        _mood.text = mood.ToString();
    }
}
