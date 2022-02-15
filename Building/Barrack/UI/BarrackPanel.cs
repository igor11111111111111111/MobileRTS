
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BarrackPanel : DemolishableBuildingPanel
{
    public static BarrackPanel Instance { get; private set; }

    [SerializeField] private GameObject _productionElementTemplate;
    [SerializeField] private Transform _possibleProductionElementsContainer;
    [SerializeField] private Transform _inProgressElementContainer;

    public BarrackProduction Production => _production;
    private BarrackProduction _production;

    public void Awake()
    {
        Instance = this;
    }

    public void DisplayProduction(BarrackProduction building, BuildingProfile profile) 
    {
        DisplayDefaultInfo(profile);
        _production = building;

        Subscriptions();
        DrawProgressQueue();
        DrawPossibleProduction();
    }

    private void Subscriptions()
    {
        if (_production != null)
        {
            _production.OnTimeChange -= OnTimeProductionChangeHandler;
            _production.OnAdd -= OnAddHandler;
            _production.OnNormalCompletion -= OnNormalCompletionHandler;
            _production.OnExtremeCompletion -= OnExtremeCompletionHandler;
        }

        _production.OnTimeChange += OnTimeProductionChangeHandler;
        _production.OnAdd += OnAddHandler;
        _production.OnNormalCompletion += OnNormalCompletionHandler;
        _production.OnExtremeCompletion += OnExtremeCompletionHandler;
    } 

    private void OnTimeProductionChangeHandler()
    {
        if (_inProgressElementContainer.childCount == 0) return;

        var firstProduct = _inProgressElementContainer.GetChild(0);
        var presenter = firstProduct.GetComponent<BarrackPresenterOnButton>();

        if (_production.ElementsInProgress.Count() == 0) return;

        var inProduction = _production.ElementsInProgress.First();
        var time = inProduction.NormalizedProductionTime;
        presenter.SetProgress(time);
    }

    private void OnAddHandler(BarrackProduction.InProduction inProduction)
    {
        var go = Instantiate(_productionElementTemplate, _inProgressElementContainer);
        var presenter = go.GetComponent<BarrackPresenterOnButton>();
        presenter.Present(inProduction.Element, () =>
        {
            _production.RemoveFromProduction(inProduction, presenter.gameObject);
        });
    }

    private void OnNormalCompletionHandler(BarrackProduction.InProduction inProgress, Enums.Team team)
    {
        DrawProgressQueue();
    }

    private void OnExtremeCompletionHandler(BarrackProduction.InProduction inProduction)
    {
        if (_inProgressElementContainer.childCount == 0) return;

        var gameObject = _inProgressElementContainer.GetChild(0);
        var presenter = gameObject.GetComponent<BarrackPresenterOnButton>();
        presenter.SetProgress(0);
    }

    private void DrawProgressQueue()
    {
        _inProgressElementContainer.ClearChild();
        foreach (var inProgress in _production.ElementsInProgress)
        {
            var go = Instantiate(_productionElementTemplate, _inProgressElementContainer);
            var presenter = go.GetComponent<BarrackPresenterOnButton>();
            presenter.Present(inProgress.Element, () =>
            {
                _production.RemoveFromProduction(inProgress, presenter.gameObject);
            });
            presenter.SetProgress(inProgress.NormalizedProductionTime);
        }
    }

    private void DrawPossibleProduction()
    {
        _possibleProductionElementsContainer.ClearChild();

        foreach (var product in _production.PossibleProduction)
        {
            var go = Instantiate(_productionElementTemplate, _possibleProductionElementsContainer);
            go.GetComponent<BarrackPresenterOnButton>().Present(product, () => 
            {
                _production.TryAddInProduction(product);
            });
        }
    }
}
