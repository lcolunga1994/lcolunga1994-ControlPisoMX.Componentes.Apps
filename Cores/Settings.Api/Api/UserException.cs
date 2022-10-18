namespace System
{
    public class UserException : Exception
    {
        #region Fields

        private const string CustomException = "customException";
        private const string InternalException = "InternalError";

        #endregion

        #region Properties

        public string? ErrorCode => Data["errorCode"]?.ToString();

        public bool IsInternalException => (Data["errorType"]?.ToString() ?? CustomException) == InternalException;

        public int SystemErrorCode => Convert.ToInt32(Data["systemErrorCode"]);

        #endregion

        #region Constructor

        public UserException()
        {
            SetAsCustomException();
        }

        public UserException(string? message)
            : base(message)
        {
            SetAsCustomException();
            SetSystemErrorCode(401);
        }

        public UserException(string? message, string errorCode, bool isInternalException = false)
            : this(message)
        {
            SetErrorCode(errorCode);
            SetSystemErrorCode(isInternalException? 500 : 401);
            if (isInternalException)
            {
                SetAsInternalException();
            }
        }

        protected UserException(string? message, Exception? innerException, bool isInternalException = false)
            : base(message, innerException)
        {
            SetAsCustomException();
            SetSystemErrorCode(isInternalException? 500 : 401);
            if (isInternalException)
            {
                SetAsInternalException();
            }
        }

        protected UserException(string? message, Exception? innerException, int systemErrorCode)
            : base(message, innerException)
        {
            SetSystemErrorCode(systemErrorCode);
            SetAsCustomException();
            if (systemErrorCode is 500)
            {
                SetAsInternalException();
            }
        }

        public UserException(string? message, int systemErrorCode)
            : base(message)
        {
            SetSystemErrorCode(systemErrorCode);
            SetAsCustomException();
            if (systemErrorCode is 500)
            {
                SetAsInternalException();
            }
        }

        protected UserException(string? message, Exception? innerException, string errorCode, bool isInternalException = false)
            : this(message, innerException, isInternalException)
        {
            SetSystemErrorCode(isInternalException ? 500 : 401);
            SetErrorCode(errorCode);
        }

        #endregion

        #region Methods

        public static UserException WithInnerException(string message, Exception? innerException)
        {
            return message is null
                ? throw new ArgumentNullException(nameof(message))
                : innerException is not null and UserException userException ? userException : new UserException(message, innerException, true);
        }

        #endregion

        #region Functionality

        private void SetErrorCode(string errorCode) => Data["errorCode"] = errorCode;

        private void SetAsCustomException() => Data["errorType"] = CustomException;

        private void SetAsInternalException() => Data["errorType"] = InternalException;

        private void SetSystemErrorCode(int systemErrorCode) => Data["systemErrorCode"] = systemErrorCode;

        #endregion
    }
}