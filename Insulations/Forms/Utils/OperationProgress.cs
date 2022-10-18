namespace ProlecGE.ControlPisoMX.Insulations.Forms.Utils
{
    using System;

    public enum OperationState
    {
        WaitingToRun = 0,
        Started = 1,
        Running = 2,
        Canceled = 3,
        Error = 4,
        Finished = 5
    }

    public record OperationProgressReport<T>(OperationState State, T? Value, string? ErrorMessage, Exception? Exception);

    public class OperationProgress<T> : Progress<OperationProgressReport<T>>
    {
        #region Constructor

        public OperationProgress(Action<OperationProgressReport<T>> handler)
            : base(handler) { }
                
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

        public void Error(string errorMessage, Exception exception)
        {
            Status = OperationState.Error;
            OnReport(new OperationProgressReport<T>(Status, default, errorMessage, exception));
        }

        public void Finish(T? progress = default)
            => SetStatus(OperationState.Finished, progress);

        private void SetStatus(OperationState status, T? progress)
        {
            Status = status;
            OnReport(new OperationProgressReport<T>(status, progress, null, null));
        }

        #endregion
    }
}