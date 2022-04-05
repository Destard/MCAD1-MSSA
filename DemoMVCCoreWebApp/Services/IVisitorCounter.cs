namespace DemoMVCCoreWebApp.Services
{
    public interface IVisitorCounter
    {
        int CounterValue { get; }
        void IncrementCounter();
        void ResetCounter();
    }
}
