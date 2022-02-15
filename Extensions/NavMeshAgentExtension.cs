using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMeshAgentExtension : MonoBehaviour
{
    public event UnityAction<float> OnAgentSpeed;
    private NavMeshAgent _agent;
    private Unit _unit;
    private float oldMagnitude = 0;
    private float newMagnitude = 0;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _unit = GetComponent<Unit>();
        _unit.OnDeath += () => OnDeathHandler();
    }

    private void OnDestroy()
    {
        _unit.OnDeath -= () => OnDeathHandler();
    }

    private void Update()
    {
        oldMagnitude = newMagnitude;
        newMagnitude = _agent.velocity.magnitude;

        if (oldMagnitude == newMagnitude && newMagnitude == 0) return;

        float normalizedSpeed = _agent.velocity.magnitude / _agent.speed;
        OnAgentSpeed.Invoke(normalizedSpeed); 
    }

    private void OnDeathHandler()
    {
        Destroy(_agent);
        Destroy(this);
    }
}
