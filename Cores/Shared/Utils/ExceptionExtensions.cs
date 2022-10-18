namespace System
{
    public static class ExceptionExtensions
    {
        public static string GetInnerMessage(this Exception exception)
        {
            if (exception != null)
            {
                if (exception.InnerException != null)
                {
                    return GetInnerMessage(exception.InnerException);
                }

                Diagnostics.Debug.WriteLine(exception);
                return exception.Message;
            }

            return string.Empty;
        }
    }
}