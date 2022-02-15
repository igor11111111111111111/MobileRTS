

public class Worker : IEmployed
{
    public DismissAction Dismiss { get; private set; } = new DismissAction();
}
