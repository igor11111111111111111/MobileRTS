using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    protected Animator _animator;
    protected NavMeshAgentExtension _agent;
    protected Unit _unit;
    protected Logic _logic;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _unit = GetComponent<Unit>();
        _logic = GetComponent<Logic>();

        _animator.speed = Random.Range(_animator.speed - 0.1f, _animator.speed + 0.1f);

        _unit.OnDeath += Death;
    }

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgentExtension>();
        _agent.OnAgentSpeed += SetAnimatorSpeed;
    }

    private void OnDisable()
    {
        _agent.OnAgentSpeed -= SetAnimatorSpeed;
    }

    private void SetAnimatorSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    protected virtual void Death()
    {
        _animator.SetTrigger("IsDeath");
        _animator.SetInteger("DeathIndex", Random.Range(1, 3));

        _unit.OnDeath -= Death;
    }
}
