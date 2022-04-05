namespace DemoMVCCoreWebApp.Services
{
    public class VisitorCounter : IVisitorCounter
    {
        public int CounterValue { get; private set; }

        public async void IncrementCounter()
        {
            CounterValue++;
            // IncrementCounterAsync().Wait(); //Hard wait until it finishes.
            // await IncrementCounterAsync(); //Suspend execution of this method until the calling task finishes.
            // var task1 = IncrementCounterAsync();
            // var task2 = IncrementCounterAsync();
            //Task.WaitAll(task1, task2);

        }

        public void ResetCounter()
        {
            CounterValue = 0;
        }
        // public async Task IncrementCounterAsync()
        // {
        //     return Task.Delay(1000);
        // }
    }
}
