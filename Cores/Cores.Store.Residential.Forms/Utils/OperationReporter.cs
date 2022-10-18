namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Forms.Utils
{
    using System;
    using System.Threading;

    public enum OperationState
    {
        WaitingToRun = 0,
        Started = 1,
        Running = 2,
        Canceled = 3,
        Finished = 4
    }

    public class OperationReporter<T>
    {
        #region Fields

        private static readonly object lockObject = new();
        private readonly IProgress<OperationProgress<T>> progressReporter;

        #endregion

        #region Properties

        public OperationReporter(Action<OperationProgress<T>> handler)
        {
            progressReporter = new Progress<OperationProgress<T>>(handler);
        }

        #endregion

        #region Properties

        public OperationState Status { get; private set; }

        public T? Progress { get; set; }

        #endregion

        #region Methods

        public void Start(T? progress = default)
            => SetStatus(OperationState.Started, progress);

        public void Cancel(T? progress = default)
            => SetStatus(OperationState.Canceled, progress);

        public void Report(T? progress)
            => SetStatus(OperationState.Running, progress);

        public void Finish(T? progress = default)
            => SetStatus(OperationState.Finished, progress);

        public void FinishReport() => Monitor.Exit(lockObject);

        private void SetStatus(OperationState status, T? progress)
        {
            Status = status;
            progressReporter.Report(new OperationProgress<T>(status, progress));
        }

        #endregion
    }

    public record OperationProgress<T>(OperationState State, T? Value);
}