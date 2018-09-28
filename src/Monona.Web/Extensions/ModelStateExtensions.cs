using Microsoft.AspNetCore.Mvc.ModelBinding;
using Monona.Services;
using System;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ModelStateExtensions
    {
        public static void AddResultErrors(this ModelStateDictionary modelState, ServiceResult result)
        {
            if (result != null && !result.Succeeded)
            {
                result.Errors.ForEach(error => modelState.AddModelError(error.FieldName, error.Message));
            }
        }
    }
}
