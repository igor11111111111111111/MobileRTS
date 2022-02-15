

public class Wood : Producer
{
    public static Wood Instance;

    protected override void OnEnable()
    {
        base.OnEnable();
        Instance = this;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Instance = null;
    }

    protected override float AdditiveIncome()
    {
        return 0;
    }
}
