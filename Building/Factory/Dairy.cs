

public class Dairy : Factory
{
    private void Awake()
    {
        _efficiency = new Efficiency(10, 20, FindObjectOfType<Granary>());
        _producer = Food.Instance;
    }
}
