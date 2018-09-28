using System;
using System.Collections.Generic;

namespace Monona.Services
{
    public class ServiceResult
    {
        private List<ServiceMessage> _errors = new List<ServiceMessage>();

        public bool Succeeded
        {
            get { return _errors.Count == 0; }
        }

        public IReadOnlyCollection<ServiceMessage> Errors
        {
            get { return _errors; }
        }

        public void AddError(string errorMessage, string fieldName = null)
        {
            AddError(new ServiceMessage(errorMessage, fieldName));
        }

        public void AddError(ServiceMessage error)
        {
            error.ThrowIfNull(nameof(error));
            _errors.Add(error);
        }

        public void MergeResult(ServiceResult result)
        {
            result.ThrowIfNull(nameof(result));
            if (!result.Succeeded)
            {
                _errors.AddRange(result.Errors);
            }
        }
    }

    public class ServiceResult<TReturnData> : ServiceResult
    {
        public TReturnData Data { get; set; }
    }
}
