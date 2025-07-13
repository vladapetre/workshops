using CleanArchitecture.Api.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchitecture.Api.Controllers.ModelBinders;

public class TemperatureScaleModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            // No value provided
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // Map string to TemperatureScale static instances
        TemperatureScale scale = value switch
        {
            var s when !string.IsNullOrEmpty(s) => new TemperatureScale(s),
            _ => TemperatureScale.Unknown,
        };

        bindingContext.Result = ModelBindingResult.Success(scale);
        return Task.CompletedTask;
    }
}