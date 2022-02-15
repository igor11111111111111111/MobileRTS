using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BarrackProduction : MonoBehaviour
{ 
    public event UnityAction<InProduction> OnAdd; 
    public event UnityAction<InProduction, Enums.Team> OnNormalCompletion;
    public event UnityAction<InProduction> OnExtremeCompletion;
    public event UnityAction OnTimeChange;
    public IEnumerable<InProduction> ElementsInProgress { get { return _elementsInProgress; }}
    private Queue<InProduction> _elementsInProgress = new Queue<InProduction>();
    public IEnumerable<ProductionElement> PossibleProduction { get { return _possibleProduction; } }
    [SerializeField]
    private List<ProductionElement> _possibleProduction;
    [SerializeField]
    private ResourceProfile _goldProfile;
    [SerializeField]
    private PeopleProfile _peopleProfile;

    public void TryAddInProduction(ProductionElement element)
    {
        if (!_possibleProduction.Contains(element)) throw new System.InvalidOperationException();

        if(_goldProfile.Value < element.Price.Value || _peopleProfile.Unemployed == 0)
        {
            // звук / картинка нужно больше золота || нужны люди
            return;
        }
        _goldProfile.Value -= element.Price.Value;
        _peopleProfile.Value--;

        var inProduction = new InProduction(element, 0);
        _elementsInProgress.Enqueue(inProduction);

        if (OnAdd != null)
        {
            OnAdd.Invoke(inProduction);
        }
    }

    private void Update()
    {
        if (_elementsInProgress.Count == 0) return;
        var inProgress = _elementsInProgress.Peek();
        inProgress.ApplyDelta(Time.deltaTime);

        if (inProgress.NormalizedProductionTime >= 1)
        {
            _elementsInProgress.Dequeue();
            if (OnNormalCompletion != null)
            {
                var team = GetComponent<Building>().Team;
                OnNormalCompletion.Invoke(inProgress, team);
            }
        }
    }

    public IEnumerator CustomUpdate()
    {
        while(GetInstanceID() == BarrackPanel.Instance.Production.GetInstanceID())
        {
            if (OnTimeChange != null)
            {
                OnTimeChange.Invoke();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void RemoveFromProduction(InProduction inProgress, GameObject gameObject)
    {
        _goldProfile.Value += inProgress.Element.Price.Value;
        _peopleProfile.Value++;

        _elementsInProgress = new Queue<InProduction>(_elementsInProgress.Where((x) => x != inProgress));
        if (OnExtremeCompletion != null)
        {
            Destroy(gameObject);
            OnExtremeCompletion.Invoke(inProgress);
        }
    }

    public class InProduction
    {
        public ProductionElement Element { get; private set; }
        public float ProductionTime { get; private set; }

        public InProduction(ProductionElement element, float productionTime)
        {
            Element = element;
            ProductionTime = productionTime;
        }

        public float NormalizedProductionTime
        {
            get
            {
                return ProductionTime / Element.TimeForConstruct;
            }
        }

        public void ApplyDelta(float delta)
        {
            ProductionTime += delta;
        }
    }
}
