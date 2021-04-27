using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Interview_Project.ActionFilters
{
    public class TrimInputStringsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var (key, value) in context.ActionArguments.ToList())
            {
                if (value is string)
                {
                    if (value == null)
                    {
                        continue;
                    }

                    string val = value as string;
                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        context.ActionArguments[key] = val.Trim();
                    }

                    continue;
                }

                Type argType = value.GetType();
                if (!argType.IsClass)
                {
                    continue;
                }

                TrimAllStringsInObject(value, argType);
            }
        }
        
        private void TrimAllStringsInObject(object arg, Type argType)
        {
            var stringProperties = argType.GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = stringProperty.GetValue(arg, null) as string;
                if (!string.IsNullOrEmpty(currentValue))
                {
                    stringProperty.SetValue(arg, currentValue.Trim(), null);
                }
            }
        }
    }
}