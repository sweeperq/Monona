namespace System
{
    public static class ExceptionExtensions
    {
        public static Exception GetInnerMost(this Exception ex)
        {
            var innerMost = ex;
            while (innerMost.InnerException != null)
            {
                innerMost = innerMost.InnerException;
            }
            return innerMost;
        }
    }
}
