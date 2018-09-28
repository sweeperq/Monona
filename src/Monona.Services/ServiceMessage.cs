using System;

namespace Monona.Services
{
    public class ServiceMessage
    {
        public ServiceMessage(string message, string fieldName = null)
        {
            message.ThrowIfEmpty(nameof(message));
            Message = message;
            FieldName = fieldName ?? string.Empty;
        }

        public string Message { get; }

        public string FieldName { get; }
    }
}
