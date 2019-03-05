using System.Threading;

namespace console_project
{
    public class CountdownThread
    {
        public delegate void Callback();

        private readonly CountdownEvent _countdownEvent;
        private readonly Thread _thread;

        public CountdownThread(Callback call, int numberOfSignals = 1)
        {
            _countdownEvent = new CountdownEvent(numberOfSignals);

            _thread = new Thread(() =>
            {
                _countdownEvent.Wait();

                call();
            });
        }

        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;
        
        public void Signal()
        {
            if (_countdownEvent.CurrentCount > 0)
            {
                _countdownEvent.Signal();                
            }
        }

        public int CurrentCount => _countdownEvent.CurrentCount;
    }
}