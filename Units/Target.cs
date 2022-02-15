using UnityEngine;

public class Target
{
    public Unit Unit { get; private set; }
    public Collider Collider { get; private set; }

    public void Init(Unit unit, Collider collider)
    {
        Unit = unit;
        Collider = collider;
    }

    public bool InContactArea(Unit thisUnit)
    {
        if (Unit != null && (Unit.Exists || (!Unit.Exists && thisUnit is IResurrect)))
        {
            var distance = VectorExtensions.Distance(thisUnit, Unit);

            if (thisUnit is IRanged)
            {
                var deviations = (thisUnit as IRanged).StoppingDistanceDeviations;

                return
                    VectorExtensions.Distance(thisUnit, Unit) <= thisUnit.StoppingDistanceToTarget + deviations &&
                    VectorExtensions.Distance(thisUnit, Unit) >= thisUnit.StoppingDistanceToTarget - deviations;
            }

            return VectorExtensions.Distance(thisUnit, Unit) <= thisUnit.StoppingDistanceToTarget;
        }

        return false;
    }
}
