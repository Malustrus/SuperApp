using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperAppLogic
{
    public class BenchProcess
    {

        CancellationTokenSource cancellationTokenSource;
        private Task t;

        public event Action<string> OnProcessStatusUpdated;

        public void Start()
        {
            OnProcessStatusUpdated?.Invoke($"{DateTime.Now} - START PROCESS");

            cancellationTokenSource = new CancellationTokenSource();
            t = Task.Run(() =>
            {
                do
                {
                    Debug.WriteLine("update process");
                    OnProcessStatusUpdated?.Invoke($"{DateTime.Now} - Take measure....");
                    Task.Delay(1000, cancellationTokenSource.Token).Wait();
                } while (!cancellationTokenSource.IsCancellationRequested);
            });
        } 
        public void Stop()
        {
            OnProcessStatusUpdated?.Invoke($"{DateTime.Now} - STOP PROCESS");
            cancellationTokenSource.Cancel();
        }
    }
}
