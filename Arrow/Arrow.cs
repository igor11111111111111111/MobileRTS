using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    private Unit _creator;
    private float _lifeTime = 4f;

    private void OnEnable()
    {
        Invoke("Destroy", _lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Destroy()
    {
        StackArrows.Push(gameObject);
        gameObject.SetActive(false);
    }

    public void SetStartSettings(Unit creator, Unit target)
    {
        var arrowQuat = Quaternion.Euler(0, creator.transform.eulerAngles.y - 90, 90);
        gameObject.SetActive(true);

        var ranged = creator as IRanged;
        transform.SetPositionAndRotation(ranged.SpawnedAmmoTransform.position, arrowQuat);

        var speed = VectorExtensions.Distance(creator, target) * 4;

        _creator = creator;
        _rigidbody.velocity = transform.TransformDirection(Vector3.down * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unit caughtUnit = collision.transform.GetComponent<Unit>();
        if(caughtUnit != null && _creator != null && caughtUnit != _creator)
        {
            caughtUnit.ApplyDamage(_creator);
            Destroy();
        }
    }
}
