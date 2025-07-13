using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CleanArchitecture.Api;

public class TemperatureScaleModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(TemperatureScale))
        {
            return new BinderTypeModelBinder(typeof(TemperatureScaleModelBinder));
        }
        return null;
    }
}