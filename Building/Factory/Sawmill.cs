

public class Sawmill : Factory
{
    private void Awake()
    {
        _efficiency = new Efficiency(10, 20, FindObjectOfType<WareHouse>());
        _producer = Wood.Instance;
    }
}
